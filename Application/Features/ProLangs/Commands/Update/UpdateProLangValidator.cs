using FluentValidation;

namespace Application.Features.ProLangs.Commands.Update
{
    public class UpdateProLangValidator : AbstractValidator<UpdateProLangCommand>
    {
        public UpdateProLangValidator()
        {

            RuleFor(c => c.Name).NotEmpty();
        }
    }
}
