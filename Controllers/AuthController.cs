using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using XeniaCatalogueApi.Service.Common;
using XeniaTokenBackend.Repositories.Auth;

namespace XeniaTokenBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;

        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
        {
            var (token, error) = await _authRepository.LoginUserAsync(request);

            if (error != null)
                return BadRequest(new LoginResponseDto { Status = "failed", Message = error });

            return Ok(new LoginResponseDto { Status = "success", Token = token });
        }

        [HttpGet("user")]
        [Authorize]
        public async Task<IActionResult> GetUsersByToken()
        {
            try
            {
                var response = await _authRepository.GetUserByTokenAsync(User);

                if (response == null)
                    return Unauthorized(new { status = "Error", message = "Token is missing or invalid." });

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }


    }
}
