using FluentValidation;

namespace Application.Features.ProTecnologies.Commands.Create
{
    public class CreateProTechnologyValidator : AbstractValidator<CreateProTechnologyCommand>
    {
        public CreateProTechnologyValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.ProTechnologyId).GreaterThan(0);
        }
    }
}
