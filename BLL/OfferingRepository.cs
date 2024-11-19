using ChurchPlusAPI_v1._0.DataTransferObjects;
using System.Linq;
using System.Collections.Generic;
using ChurchPlusAPI_v1.DAL;

namespace ChurchPlusAPI_v1._0.BusinessLogic;

public class OfferingRepository: IOfferings
{
    private readonly DataContext _context;
    public OfferingRepository(DataContext context)
    {
        _context = context;
    }
    public List<OfferingDTO> GetOffering()
    {
        var result = (from o in _context.Offerings
        where o.Status == 1
        select new OfferingDTO {
                 Id = o.Id, Amount = o.Amount, CollectionDate = o.CollectionDate, OfferingGroupId = o.OfferingGroupId
        }).ToList<OfferingDTO>();

        return result;
    }
}