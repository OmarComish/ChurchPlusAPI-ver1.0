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
        
        CreateMap<UpdatePledgeDto, Pledge>()
        .ForMember(dest => dest.CauseCategory, opt => opt.Ignore())  // ignore nav property
        .ForMember(dest => dest.CauseCategoryId, opt => opt.MapFrom(src => src.CauseCategoryId)) // map the FK directly
        .ForMember(dest => dest.DateCreated, opt => opt.Ignore())
        .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
        .ForMember(dest => dest.ActualAmountFulfilled, opt => opt.Ignore())
        .ForMember(dest => dest.DateFulfilled, opt => opt.Ignore())
        .ForMember(dest => dest.ApprovedBy, opt => opt.Ignore())
        .ForMember(dest => dest.DateApproved, opt => opt.Ignore())
        .ForMember(dest => dest.DateApproved, opt => opt.Ignore())
        .ForMember(dest => dest.PledgeStatus, opt => opt.Ignore())
        .ForMember(dest => dest.ApprovalStatus, opt => opt.Ignore())
        .ForMember(dest => dest.ReceivedBy, opt => opt.Ignore())
        .ForMember(dest => dest.DatePledged, opt => opt.Ignore());

        CreateMap<CreateOfferingDto, Offering>()
        .ForMember(dest=>dest.ChurchServiceSession, opt=>opt.Ignore())
        .ForMember(dest => dest.ServiceSessionId, opt => opt.MapFrom(src => src.ServiceSessionId));

        CreateMap<Offering, ReadOfferingDto>()
          .ForMember(dest=>dest.ServiceSession, opt=>opt.MapFrom(src=>src.ChurchServiceSession.SessionName))
          .ForMember(dest=>dest.Status, opt=>opt.MapFrom(src=>(RecordStatus)src.Status));

        CreateMap<Expense, CreateExpenseDto>().ReverseMap();
        CreateMap<Expense, ReadExpenseDto>()
        .ForMember(dest=>dest.ApprovalStatus, opt=>opt.MapFrom(src=>(RecordStatus)src.ApprovalStatus))
        .ForMember(dest=>dest.ExpenseStatus, opt=>opt.MapFrom(src=>(RecordStatus)src.ExpenseStatus));
    }
}