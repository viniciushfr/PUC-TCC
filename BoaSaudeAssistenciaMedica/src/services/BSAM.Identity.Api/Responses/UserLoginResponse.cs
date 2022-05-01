namespace BSAM.Identity.Api.Responses
{
    public class UserLoginResponse : BaseResponse
    {
        public string AccessToken { get; set; } = string.Empty;
        public Guid RefreshToken { get; set; }
        public double ExpiresIn { get; set; }
        public UserToken UserToken { get; set; }
    }
}
