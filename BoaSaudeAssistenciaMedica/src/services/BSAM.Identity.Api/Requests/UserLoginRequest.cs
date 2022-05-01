namespace BSAM.Identity.Api.Requests
{
    public class UserLoginRequest
    {
        public UserLoginRequest(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public string Email { get; private set; } = string.Empty;
        public string Password { get; private set; } = string.Empty;
    }
}
