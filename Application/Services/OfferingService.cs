using System.Data.Common;
using AutoMapper;
using ChurchPlusAPI_v1._0.Application.Interfaces;
using ChurchPlusAPI_v1._0.DTOs;
using ChurchPlusAPI_v1._0.Models;
using ChurchPlusAPI_v1.DAL;
using Microsoft.EntityFrameworkCore;

namespace ChurchPlusAPI_v1._0.Application.Services;

public class OfferingService : IOffering
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    public OfferingService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<ResponseDto> Create(CreateOfferingDto dto, int collectedBy)
    {
        var response = new ResponseDto{Status ="error", Message ="Failed to add Offering"};
        if(dto!=null)
        {
            var rs = _mapper.Map<Offering>(dto);
            rs.CollectedBy = collectedBy;
            rs.CollectionDate = DateTime.UtcNow;
            rs.Status = RecordStatus.Pending;
            
            await  _context.AddAsync(rs);
            await _context.SaveChangesAsync();
            
            response.Status ="success";
            response.Message =$"Offering for {rs.ChurchServiceSession} added successully!";
        }
        return response;
    }

    public async Task<ResponseDto> GetOfferingById(int offeringId, CancellationToken cancellationToken = default)
    {
        var response = new ResponseDto {Status ="error", Message="Invalid or null offering ID"};
          // Edge case: invalid ID
        if (offeringId <= 0)
        {
            response.Message =$"Offering ID must be a positive integer {nameof(offeringId)}";
        }
        try
        {
            var offering = await _context.Offerings
            .Include(s=>s.ChurchServiceSession)
            .FirstOrDefaultAsync(s=>s.Id==offeringId, cancellationToken);

            //Edge case: Offering not found
            if(offering is null)
            {
                response.Message = $"Offering with ID {offeringId} was not found";
            }
            response.Status ="success";
            response.Message ="Fetch operation successful";
            response.Payload = _mapper.Map<ReadOfferingDto>(offering);
        }
        catch(OperationCanceledException)
        {
            throw new OperationCanceledException("The request was cancelled");
        }
        catch(DbException ex)
        {
            throw new ApplicationException("A database error occurred while retrieving the offering.", ex);
        }
        catch(Exception ex)
        {
             throw new ApplicationException("An unexpected error occurred while retrieving the offering.",ex);
        }
        return response;
    }

    public async Task<ResponseDto> GetOfferingList()
    {
        var response = new ResponseDto {Status ="error", Message="An error occurred whilte fetching offerings data"};
  
        try
        {
            
            var offering = await _context.Offerings.Include(s=>s.ChurchServiceSession).ToListAsync();

            //Edge case: Offering not found
            if(offering is null)
            {
                response.Message = $"No Offerings were found";
            }
            response.Status ="success";
            response.Message =$"Fetch operation successful. Found {offering.Count} entries";
            response.Payload = _mapper.Map<IEnumerable<ReadOfferingDto>>(offering);
        }
        catch(OperationCanceledException)
        {
            throw new OperationCanceledException("The request was cancelled");
        }
        catch(DbException ex)
        {
            throw new ApplicationException("A database error occurred while retrieving offering.", ex);
        }
        catch(Exception ex)
        {
             throw new ApplicationException("An unexpected error occurred while retrieving offering.",ex);
        }
        return response;
    }

    public Task<ResponseDto> Update(UpdatePledgeDto pledge)
    {
        throw new NotImplementedException();
    }
}