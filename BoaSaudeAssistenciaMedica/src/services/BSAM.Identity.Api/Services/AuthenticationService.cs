using BSAM.Identity.Api.Requests;
using BSAM.Identity.Api.Responses;
using Microsoft.AspNetCore.Identity;

namespace BSAM.Identity.Api.Services
{
    public class AuthenticationService
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<AuthenticationService> _logger;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly TokenService _tokenService;

        public AuthenticationService(
            SignInManager<IdentityUser> signInManager,
            ILogger<AuthenticationService> logger,
            UserManager<IdentityUser> userManager,
            TokenService tokenService)
        {
            _signInManager = signInManager;
            _logger = logger;
            _userManager = userManager;
            _tokenService = tokenService;
        }

        public async Task<UserLoginResponse> Register(UserRegisterRequest request)
        {
            try
            {
                _logger.LogInformation("Registrando usuario - {login}", request.Email);

                var user = new IdentityUser { UserName = request.Email, Email = request.Email, EmailConfirmed = true };

                var response = new UserLoginResponse();

                var result = await _userManager.CreateAsync(user, request.Password);

                if (result.Succeeded)
                    return await _tokenService.GenerateJwt(request.Email);

                return GetIdentityErrors(result);

            }
            catch (Exception ex)
            {
                _logger.LogError("Error : {error}  ---  Message : {message}", ex, ex.Message);
                throw new Exception(ex.Message);
            }
        }

      

        public async Task<UserLoginResponse> Login(UserLoginRequest request)
        {
            try
            {
                _logger.LogInformation("Logando usuario - {login}", request.Email);

                var response = new UserLoginResponse();
                var result = await _signInManager.PasswordSignInAsync(request.Email, request.Password, false, true);

                if (result.Succeeded)
                    return await _tokenService.GenerateJwt(request.Email);

                if (result.IsLockedOut) 
                {   
                    response.AddError("Usuário temporiamente bloqueado por tentativas inválidas");
                    return response;
                }

                response.AddError("Usuário ou Senha incorretos");
                return response;

            }
            catch (Exception ex)
            {
                _logger.LogError("Error : {error}  ---  Message : {message}", ex, ex.Message);
                throw new Exception(ex.Message);
            }
        }

        private static UserLoginResponse GetIdentityErrors(IdentityResult result)
        {
            var response = new UserLoginResponse();
            
            foreach (var error in result.Errors)
                response.AddError(error.Description);

            return response;
        } 
    }
}
