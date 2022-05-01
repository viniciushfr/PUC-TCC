using FluentValidation;

namespace BSAM.Identity.Api.Requests.Validators
{
    public class UserRegisterRequestValidator : AbstractValidator<UserRegisterRequest>
    {
        public UserRegisterRequestValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull()
                .WithMessage("Informar  email");

            RuleFor(x => x.Password)
                .NotEmpty()
                .NotNull()
                .WithMessage("Informar senha");


            RuleFor(x => x.ConfirmationPassword)
               .NotEmpty()
               .NotNull()
               .WithMessage("Informar confirmação de senha");
        }
    }
}
