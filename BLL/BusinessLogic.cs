using System;
using ChurchPlusAPI_v1._0.DataTransferObjects;

namespace ChurchPlusAPI_v1._0.BusinessLogic;

public interface IOfferings
{
    List<OfferingDTO> GetOffering();
}
