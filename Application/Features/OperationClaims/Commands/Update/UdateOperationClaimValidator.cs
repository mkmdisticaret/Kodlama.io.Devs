using FluentValidation;

namespace Application.Features.OperationClaims.Commands.Update
{
    public class UdateOperationClaimValidator : AbstractValidator<UpdateOperationClaimCommand>
    {
        public UdateOperationClaimValidator()
        {
            RuleFor(c => c.OperationClaimId).GreaterThan(0);
            RuleFor(c => c.Name).NotEmpty();
        }
    }
}
