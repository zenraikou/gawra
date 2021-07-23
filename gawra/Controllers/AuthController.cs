using System.Threading.Tasks;
using gawra.DTOs;
using gawra.Services;
using Microsoft.AspNetCore.Mvc;

namespace gawra.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto dto)
        {
            await _authService.CreateUserAsync(dto);
            return Ok();
        }
        
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var result = await _authService.LoginAsync(dto);
            return Ok(new {
                Token = result.token,
                ValidTo = result.ValidTo
            });
        }
    }
}