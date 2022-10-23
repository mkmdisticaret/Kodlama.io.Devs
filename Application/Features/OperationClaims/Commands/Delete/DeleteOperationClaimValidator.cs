using FluentValidation;

namespace Application.Features.OperationClaims.Commands.Delete
{
    public class DeleteOperationClaimValidator:AbstractValidator<DeleteOperationClaimCommand>
    {
        public DeleteOperationClaimValidator()
        {
            RuleFor(c => c.OperationClaimId).GreaterThan(0);
        }
    }
}
