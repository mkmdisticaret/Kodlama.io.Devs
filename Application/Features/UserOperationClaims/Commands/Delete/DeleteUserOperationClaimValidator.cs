using FluentValidation;

namespace Application.Features.UserOperationClaims.Commands.Delete
{
    public class DeleteUserOperationClaimValidator : AbstractValidator<DeleteUserOperationClaimCommand>
    {
        public DeleteUserOperationClaimValidator()
        {
            RuleFor(c => c.Id).GreaterThan(0);
        }
    }
}
