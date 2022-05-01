using MediatR;

namespace BSAM.Identity.Api.Commands
{
    public class UserRegisterCommand : IRequest
    {
        public UserRegisterCommand(string email, string password, string confirmationPassword)
        {
            Email = email;
            Password = password;
            ConfirmationPassword = confirmationPassword;
        }

        public string Email { get; private set; } = string.Empty;
        public string Password { get; private set; } = string.Empty;
        public string ConfirmationPassword { get; private set; } = string.Empty;
    }
}
