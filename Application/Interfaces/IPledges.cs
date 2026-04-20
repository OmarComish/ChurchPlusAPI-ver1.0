using ChurchPlusAPI_v1._0.DTOs;

namespace ChurchPlusAPI_v1._0.Application.Interfaces;
public interface IPledges
{
     Task<ResponseDto> Create(CreatePledgeDto createpledge);

}