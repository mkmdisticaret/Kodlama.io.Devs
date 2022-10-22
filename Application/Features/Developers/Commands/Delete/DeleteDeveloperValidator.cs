using FluentValidation;

namespace Application.Features.Developers.Commands.Delete
{
    public class DeleteDeveloperValidator:AbstractValidator<DeleteDeveloperCommand>
    {
        public DeleteDeveloperValidator()
        {
            RuleFor(c => c.DeveloperId).GreaterThan(0);
        }
    }
}
