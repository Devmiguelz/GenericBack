using GenericBack.Application.DTOs.Auth;
using GenericBack.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GenericBack.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
        {
            var result = await _authService.AuthenticateAsync(request);
            if (result == null)
                return Unauthorized("Credenciales inválidas");
            return Ok(result);
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> RefreshToken([FromBody] string refreshToken)
        {
            var result = await _authService.RefreshTokenAsync(refreshToken);
            if (result == null)
                return Unauthorized("Token de refresco inválido o expirado");
            return Ok(result);
        }
    }
}
