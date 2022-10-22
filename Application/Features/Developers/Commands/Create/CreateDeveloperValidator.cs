using FluentValidation;

namespace Application.Features.Developers.Commands.Create
{
    public class CreateDeveloperValidator : AbstractValidator<CreateDeveloperCommand>
    {
        public CreateDeveloperValidator()
        {
            RuleFor(c => c.UserId).GreaterThan(0);
            RuleFor(c => c.GitHubAddres).NotEmpty();
        }
    }
}
