using FluentValidation;

namespace BSAM.Identity.Api.Requests.Validators
{
    public class UserLoginRequestValidator : AbstractValidator<UserLoginRequest>
    {
        public UserLoginRequestValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull()
                .WithMessage("Informar  email");

            RuleFor(x => x.Password)
                .NotEmpty()
                .NotNull()
                .WithMessage("Informar senha");
        }
    }
}
