
using ChurchPlusAPI_v1._0.DTOs;
namespace ChurchPlusAPI_v1._0.Application.Interfaces;
public interface IOffering
{
     Task<ResponseDto> Create(CreateOfferingDto dto, int collectedBy);
     Task<ResponseDto> Update(UpdatepldgeDto pledge);
     Task<ResponseDto> GetOfferingList();
     Task<ResponseDto> GetOfferingById(int offeringId, CancellationToken cancellationToken = default);
}