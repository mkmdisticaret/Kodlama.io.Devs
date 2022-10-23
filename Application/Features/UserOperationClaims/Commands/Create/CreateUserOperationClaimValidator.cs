using FluentValidation;

namespace Application.Features.UserOperationClaims.Commands.Create
{
    public class CreateUserOperationClaimValidator : AbstractValidator<CreateUserOperationClaimCommand>
    {
        public CreateUserOperationClaimValidator()
        {
            RuleFor(c => c.UserId).GreaterThan(0);
            RuleFor(c => c.OperationClaimId).GreaterThan(0);
        }
    }
}
