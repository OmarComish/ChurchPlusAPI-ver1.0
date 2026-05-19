using ChurchPlusAPI_v1._0.DTOs;

namespace ChurchPlusAPI_v1._0.Application.Interfaces;
public interface IAuthentication
{
    Task<AuthResponseDto> AuthenticateUser(LogInRequestDto dto);
    Task<ResponseDto> RegisterUser(RegisterUserDto dto);
}