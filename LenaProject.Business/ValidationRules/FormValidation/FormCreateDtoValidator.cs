using FluentValidation;

namespace LenaProject.Business.ValidationRules.FormValidation
{
    public class FormCreateDtoValidator : AbstractValidator<FormCreateDto>
    {
        public FormCreateDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name can not be empty");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description can not be empty");

        }
    }
}
