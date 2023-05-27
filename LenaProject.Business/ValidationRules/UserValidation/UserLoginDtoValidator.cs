using FluentValidation;

namespace LenaProject.Business.ValidationRules.UserValidation
{
    public class UserLoginDtoValidator : AbstractValidator<UserLoginDto>
    {
        public UserLoginDtoValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Username or Password is wrong.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Username or Password is wrong.");

        }
    }
}
