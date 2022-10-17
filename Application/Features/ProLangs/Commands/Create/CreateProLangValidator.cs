using FluentValidation;

namespace Application.Features.ProLangs.Commands.Create
{
    public class CreateProLangValidator : AbstractValidator<CreateProLangCommand>
    {
        public CreateProLangValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
        }
    }
}
