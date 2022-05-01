using BSAM.Identity.Api.Models;

namespace BSAM.Identity.Api.Responses
{
    public class RefreshTokenResponse : BaseResponse
    {
        public RefreshToken RefreshToken { get; set; }
    }
}
