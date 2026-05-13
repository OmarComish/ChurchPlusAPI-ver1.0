using ChurchPlusAPI_v1._0.DTOs;

namespace ChurchPlusAPI_v1._0.Application.Interfaces;
public interface IPledges
{
     Task<ResponseDto> Create(CreatePledgeDto createpledge);
     Task<ResponseDto> GetPledgesList();
     Task<ResponseDto> GetPledgeById(int pledgeId, CancellationToken cancellationToken = default);
     Task<ResponseDto> OwnerPledge(OwnerPledgeDto plegde);
     Task<ResponseDto> Update(UpdatePledgeDto pledge);
}