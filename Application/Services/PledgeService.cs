using AutoMapper;
using ChurchPlusAPI_v1._0.Application.Interfaces;
using ChurchPlusAPI_v1._0.DTOs;
using ChurchPlusAPI_v1._0.Models;
using ChurchPlusAPI_v1.DAL;

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
            rs.Status = 1;
            await  _context.AddAsync(rs);
            await _context.SaveChangesAsync();
            response.Message =$"Pledge for {createpledge.PledgedBy} added successully!";
        }
        return response;
    }
}