using System.Text.Json.Serialization;

namespace BSAM.Identity.Api.Responses
{
    public abstract class BaseResponse
    {
        public ValidatorResult Result { get; set; } = new();

        public void AddError(string errorMessage)
        {
            Result?.Errors.Add(errorMessage);
        }

        public void AddErrors(List<string> errorsMessages) 
        {
            Result?.Errors.AddRange(errorsMessages);
        }
    }

    public class ValidatorResult 
    {
        public List<string> Errors { get; set; } = new();
    }
}
