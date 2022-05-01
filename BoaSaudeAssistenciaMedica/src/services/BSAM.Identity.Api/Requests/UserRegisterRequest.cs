namespace BSAM.Identity.Api.Requests
{
    public class UserRegisterRequest
    {
        public UserRegisterRequest(string email, string password, string confirmationPassword)
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
