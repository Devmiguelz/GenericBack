using GenericBack.Application.DTOs.Auth;

namespace GenericBack.Application.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponseDto?> AuthenticateAsync(LoginRequestDto request);
        Task<LoginResponseDto?> RefreshTokenAsync(string refreshToken);
    }
}
