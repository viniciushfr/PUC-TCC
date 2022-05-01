using BSAM.Identity.Api.Commands;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace BSAM.Identity.Api.Handlers
{
    public class UserLoginrCommandHandler : IRequestHandler<UserLoginCommand>
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<UserRegisterCommandHandler> _logger;
        private readonly UserManager<IdentityUser> _userManager;

        public UserLoginrCommandHandler(
            SignInManager<IdentityUser> signInManager, 
            ILogger<UserRegisterCommandHandler> logger, 
            UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _logger = logger;
            _userManager = userManager;
        }

        public async Task<Unit> Handle(UserLoginCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Logando usuario - {login}", request.Email);

                var result = await _signInManager.PasswordSignInAsync(request.Email, request.Password, false, true);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error : {error}  ---  Message : {message}", ex, ex.Message);
                throw new Exception(ex.Message);
            }

            return Unit.Value;
        }
    }
}
