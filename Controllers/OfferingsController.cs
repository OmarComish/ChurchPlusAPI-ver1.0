using ChurchPlusAPI_v1._0.BusinessLogic;
using ChurchPlusAPI_v1._0.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;

namespace ChurchPlusAPI_v1._0.Controllers;
[ApiController]
[Route("api/Offerings")]
public class OfferingsController: ControllerBase
{
   private readonly IOfferings _offerings;
   public OfferingsController(IOfferings offerings)
   {
     _offerings = offerings;
   }
    [HttpGet]
    public async Task<IActionResult> GetOfferingList()
    {
        var result = await Task.Run(_offerings.GetOffering);
        return Ok(result);
    }
}