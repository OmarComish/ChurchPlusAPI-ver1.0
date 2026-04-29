using AutoMapper;
using ChurchPlusAPI_v1._0.DTOs;
using ChurchPlusAPI_v1._0.Models;

namespace ChurchPlusAPI_v1._0.RequestHelpers;
public class MappingProfiles: Profile
{
    public MappingProfiles()
    {
        CreateMap<Pledge, CreatePledgeDto>().ReverseMap();
        CreateMap<Pledge, ReadPledgeDto>()
        .ForMember(dest=>dest.CauseCategory, opt=>opt.MapFrom(src=>src.CauseCategory.CauseName))
        .ForMember(dest =>dest.Status, opt =>opt.MapFrom(src=>(RecordStatus)src.ApprovalStatus));

        CreateMap<Offering, CreateOfferingDto>().ReverseMap();
        CreateMap<Offering, ReadOfferingDto>()
          .ForMember(dest=>dest.ServiceSession, opt=>opt.MapFrom(src=>src.ChurchServiceSession.SessionName))
          .ForMember(dest=>dest.Status, opt=>opt.MapFrom(src=>(RecordStatus)src.Status));

        CreateMap<Expense, CreateExpenseDto>().ReverseMap();
        CreateMap<Expense, ReadExpenseDto>()
        .ForMember(dest=>dest.ApprovalStatus, opt=>opt.MapFrom(src=>(RecordStatus)src.ApprovalStatus))
        .ForMember(dest=>dest.ExpenseStatus, opt=>opt.MapFrom(src=>(RecordStatus)src.ExpenseStatus));
    }
}