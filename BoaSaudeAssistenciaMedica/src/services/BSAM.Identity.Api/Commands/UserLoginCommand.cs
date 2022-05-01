using MediatR;

namespace BSAM.Identity.Api.Commands
{
    public class UserLoginCommand : IRequest
    {
        public UserLoginCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public string Email { get; private set; } = string.Empty;
        public string Password { get; private set; } = string.Empty;
    }
}
