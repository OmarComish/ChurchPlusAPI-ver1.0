using ChurchPlusAPI_v1._0.DTOs;

namespace ChurchPlusAPI_v1._0.Application.Interfaces;
public interface IApiService
{
    Task<TokenResponseDto> GetTokenAsync(TokenRequestDto request);
    Task<ResponseDto> RegisterUserAsync(RegisterUserDto request);
    Task<AuthResponseDto> SignInAsync(LogInRequestDto request);
}