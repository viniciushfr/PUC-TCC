using BSAM.Identity.Api.Commands;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace BSAM.Identity.Api.Handlers
{
    public class UserRegisterCommandHandler : IRequestHandler<UserRegisterCommand>
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<UserRegisterCommandHandler> _logger;
        private readonly UserManager<IdentityUser> _userManager;

        public UserRegisterCommandHandler(
            SignInManager<IdentityUser> signInManager, 
            ILogger<UserRegisterCommandHandler> logger, 
            UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _logger = logger;
            _userManager = userManager;
        }

        public async Task<Unit> Handle(UserRegisterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Registrando usuario - {login}", request.Email);

                var user = new IdentityUser { UserName = request.Email, Email = request.Email, EmailConfirmed = true };

                var result = await _userManager.CreateAsync(user, request.Password);

                if (result.Succeeded)
                    await _signInManager.SignInAsync(user, false);
                
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
