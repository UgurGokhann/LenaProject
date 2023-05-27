using FluentValidation;

namespace LenaProject.Business.ValidationRules.UserValidation
{
    public class UserRegisterDtoValidator : AbstractValidator<UserRegisterDto>
    {
        public UserRegisterDtoValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Username can not be empty");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password can not be empty");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email can not be empty");   
        }
    }
}
