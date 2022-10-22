using FluentValidation;

namespace Application.Features.Developers.Commands.Update
{
    public class UpdateDeveloperValidator : AbstractValidator<UpdateDeveloperCommand>
    {
        public UpdateDeveloperValidator()
        {
            RuleFor(c => c.DeveloperId).GreaterThan(0);
            RuleFor(c => c.GitHubAddress).NotEmpty();
            RuleFor(c => c.UserId).GreaterThan(0);
        }
    }
}
