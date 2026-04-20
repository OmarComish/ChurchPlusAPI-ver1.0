using AutoMapper;
using ChurchPlusAPI_v1._0.DTOs;
using ChurchPlusAPI_v1._0.Models;

namespace ChurchPlusAPI_v1._0.RequestHelpers;
public class MappingProfiles: Profile
{
    public MappingProfiles()
    {
        CreateMap<Pledge, CreatePledgeDto>().ReverseMap();
    }
}