using ChurchPlusAPI_v1._0.Application.Interfaces;
using ChurchPlusAPI_v1._0.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ChurchPlusAPI_v1._0.Controllers;

[ApiController]
[Route("api/pledges/")]

public class PledgesController: ControllerBase
{
    private readonly IPledges _pledges;
    public PledgesController(IPledges pledges)
    {
        _pledges = pledges;
    }
    [HttpPost]
    public async Task<ActionResult<ResponseDto>> AddPledge(CreatePledgeDto pledgedto)
    {
        var response = new ResponseDto {Status ="error", Message ="Null pledge data. Could not save to database"};
        if(pledgedto!= null)
        {
            pledgedto.CreatedBy = 1; //Hardcoded value. Replace with actual user who received the pledge
            response = await _pledges.Create(pledgedto);
        }
        return Ok(response);
    }
    [HttpGet("{Id}")]
    public async Task<ActionResult<ResponseDto>> GetPledgeById(int Id)
    {
        var response = await _pledges.GetPledgeById(Id);
        return Ok(response);
    }
    [HttpGet]
    public async Task<ActionResult<ResponseDto>> GetPledges()
    {
        var response = await _pledges.GetPledgesList();
        return Ok(response);
    }
    [HttpPut]
    public async Task<ActionResult<ResponseDto>> UpdatePledge(UpdatepldgeDto dto)
    {
        var response = await _pledges.Update(dto);
        return Ok(response);
    }
}