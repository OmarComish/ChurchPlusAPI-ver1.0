using System.Data.Common;
using AutoMapper;
using ChurchPlusAPI_v1._0.Application.Interfaces;
using ChurchPlusAPI_v1._0.DTOs;
using ChurchPlusAPI_v1._0.Models;
using ChurchPlusAPI_v1.DAL;
using Microsoft.EntityFrameworkCore;

namespace ChurchPlusAPI_v1._0.Application.Services;

public class PledgeService : IPledges
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    public PledgeService(DataContext context, IMapper automapper)
    { 
        _context = context;
        _mapper = automapper;
    }
    public async Task<ResponseDto> Create(CreatePledgeDto createpledge)
    {
        var response = new ResponseDto{Status ="error", Message ="Failed to add pledge"};

        if(createpledge!= null)
        {
            var rs = _mapper.Map<Pledge>(createpledge);
            rs.DatePledged = DateTime.UtcNow;
            rs.ApprovalStatus = RecordStatus.Pending;

            await  _context.AddAsync(rs);
            await _context.SaveChangesAsync();
            
            response.Status ="success";
            response.Message =$"Pledge for {createpledge.PledgedBy} added successully!";
        }
        return response;
    }

    public async Task<ResponseDto> GetPledgeById(int pledgeId, CancellationToken cancellationToken = default)
    {
        var response = new ResponseDto {Status ="error", Message="Invalid or null pledge ID"};
          // Edge case: invalid ID
        if (pledgeId <= 0)
        {
            response.Message =$"Pledge ID must be a positive integer {nameof(pledgeId)}";
        }
        try
        {
            var pledge = await _context.Pledges
            .Include(p=>p.CauseCategory)
            .FirstOrDefaultAsync(p=>p.Id==pledgeId, cancellationToken);

            //Edge case: Pledge not found
            if(pledge is null)
            {
                response.Message = $"Pledge with ID {pledgeId} was not found";
            }
            response.Status ="success";
            response.Message ="Fetch operation successful";
            response.Payload = _mapper.Map<ReadPledgeDto>(pledge);
        }
        catch(OperationCanceledException)
        {
            throw new OperationCanceledException("The request was cancelled");
        }
        catch(DbException ex)
        {
            throw new ApplicationException("A database error occurred while retrieving the pledge.", ex);
        }
        catch(Exception ex)
        {
             throw new ApplicationException("An unexpected error occurred while retrieving the pledge.",ex);
        }
        return response;
    }

    public async Task<ResponseDto> GetPledgesList()
    {
        var response = new ResponseDto {Status ="error", Message="Invalid or null pledge ID"};
  
        try
        {
            var pledge = await _context.Pledges.Include(p=>p.CauseCategory).ToListAsync();

            //Edge case: Pledge not found
            if(pledge is null)
            {
                response.Message = $"No Pledges were found";
            }
            response.Status ="success";
            response.Message =$"Fetch operation successful. Found {pledge.Count} entries";
            response.Payload = _mapper.Map<IEnumerable<ReadPledgeDto>>(pledge);
        }
        catch(OperationCanceledException)
        {
            throw new OperationCanceledException("The request was cancelled");
        }
        catch(DbException ex)
        {
            throw new ApplicationException("A database error occurred while retrieving the pledge.", ex);
        }
        catch(Exception ex)
        {
             throw new ApplicationException("An unexpected error occurred while retrieving the pledge.",ex);
        }
        return response;
    }

    public async Task<ResponseDto> OwnerPledge(OwnerPledgeDto pledge)
    {
        var response = new ResponseDto {Status ="error", Message="Invalid or null pledge ID"};
        if(pledge is null) return response; 
        var rs = await _context.Pledges.Where(p =>p.Id== pledge.Id).FirstOrDefaultAsync();
        if(rs is null)
        {
            response.Message = $"Pledge ID {pledge.Id} could not be found";
            return response;
        }
        rs.ActualAmountFulfilled = pledge.AmountTendered;
        rs.DateModified = DateTime.UtcNow;
        rs.ApprovalStatus = RecordStatus.Pending;
        rs.PledgeStatus = rs.ActualAmountFulfilled == rs.AmountPledged? RecordStatus.Ownered:RecordStatus.Pending;
       
        _context.Entry(rs).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        response.Status="success";
        response.Message = $"Pledge ownered successfully";

        return response;
    }

    public async Task<ResponseDto> Update(UpdatepldgeDto pledge)
    {
        var response = new ResponseDto{Status ="error", Message ="Failed to save changes"};
        var rs = await _context.Pledges.Where(p =>p.Id == pledge.Id).FirstOrDefaultAsync();
        if(rs is null)
        {
            response.Message = $"Pledge ID {pledge.Id} could not be found";
            return response;
        }

        rs.AmountPledged = rs.AmountPledged;
        rs.CauseCategory = rs.CauseCategory;
        rs.ApprovalStatus = RecordStatus.Pending;
        rs.DateModified = DateTime.UtcNow;
        
        
        _context.Entry(rs).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        response.Status ="success";
        response.Message ="Changes saved successfully";
        return response;
    }
}