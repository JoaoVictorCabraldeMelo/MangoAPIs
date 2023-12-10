
using AuthAPI.Models.DTO;

namespace AuthAPI.Service.IService
{
    public interface IAuthService
    {
        Task<string> Register(RegistrationRequestDto requestDto);

        Task<LoginResponseDto> Login(LoginRequestDto requestDto);

        Task<bool> AssignRole(string email, string roleName);
    }
}
