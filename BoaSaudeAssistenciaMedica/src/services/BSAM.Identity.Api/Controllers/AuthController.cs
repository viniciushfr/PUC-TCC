using BSAM.Identity.Api.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BSAM.Identity.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _meadiator;

        public AuthController(IMediator meadiator)
        {
            _meadiator = meadiator;
        }


         
        [HttpPost("new-account")]
        public async Task<IActionResult> Register(UserRegisterCommand commmand)
        {
            try
            {
                await _meadiator.Send(commmand);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginCommand commmand)
        {
            try
            {
                var response = await _meadiator.Send(commmand);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
