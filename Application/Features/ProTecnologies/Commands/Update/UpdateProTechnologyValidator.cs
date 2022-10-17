using FluentValidation;

namespace Application.Features.ProTecnologies.Commands.Update
{
    public class UpdateProTechnologyValidator : AbstractValidator<UpdateProTechnologyCommand>
    {
        public UpdateProTechnologyValidator()
        {
            RuleFor(c => c.Id).GreaterThan(0);
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.ProLangId).GreaterThan(0);
        }
    }
}
