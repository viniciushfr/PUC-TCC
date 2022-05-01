using BSAM.Identity.Api.Requests;
using BSAM.Identity.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace BSAM.Identity.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthenticationService _authenticationService;
        private readonly TokenService _tokenService;

        public AuthController(AuthenticationService authenticationService, TokenService tokenService)
        {
            _authenticationService = authenticationService;
            _tokenService = tokenService;
        }
        

         
        [HttpPost("new-account")]
        public async Task<IActionResult> Register(UserRegisterRequest request)
        {
            try
            {
                return Ok(await _authenticationService.Register(request));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginRequest request)
        {
            try
            {
                return Ok(await _authenticationService.Login(request));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("refresh-token")]
        public async Task<ActionResult> RefreshToken([FromBody] string refreshToken)
        {

            try
            {
                return Ok(await _tokenService.GetRefreshToken(refreshToken));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
