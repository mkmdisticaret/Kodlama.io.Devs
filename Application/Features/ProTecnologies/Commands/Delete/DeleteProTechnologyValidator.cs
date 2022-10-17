using FluentValidation;

namespace Application.Features.ProTecnologies.Commands.Delete
{
    public class DeleteProTechnologyValidator : AbstractValidator<DeleteProTechnologyCommand>
    {
        public DeleteProTechnologyValidator()
        {
            RuleFor(c => c.Id).GreaterThan(0);
        }
    }
}
