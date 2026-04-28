using ChurchPlusAPI_v1._0.Application.Interfaces;
using ChurchPlusAPI_v1._0.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ChurchPlusAPI_v1._0.Controllers;

[ApiController]
[Route("api/offerings")]
public class OfferingsController: ControllerBase
{
    private readonly IOffering _offerings;
    public OfferingsController(IOffering offerings)
    {
        _offerings = offerings;
    }
    [HttpPost]
    public async Task<ActionResult<ResponseDto>> AddOffering(CreateOfferingDto dto)
    {
        var response = new ResponseDto {Status ="error", Message ="Null offering data. Could not save to database"};
        if(dto!= null)
        {
            dto.CollectedBy = "admin"; //Hardcoded value. Replace with actual user who received the pledge
            response = await _offerings.Create(dto);
        }
        return Ok(response);
    }
    [HttpGet("{Id}")]
    public async Task<ActionResult<ResponseDto>> GetOfferingById(int Id)
    {
        var response = await _offerings.GetOfferingById(Id);
        return Ok(response);
    }
    [HttpGet]
    public async Task<ActionResult<ResponseDto>> GetOfferings()
    {
        var response = await _offerings.GetOfferingList();
        return Ok(response);
    }
}