using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;

namespace Application.Features.OperationClaims.Rules
{
    public class OperationClaimBusinessRules
    {
        private readonly IOperationClaimRepository _operationClaimRepository;

        public OperationClaimBusinessRules(IOperationClaimRepository operationClaimRepository)
        {
            _operationClaimRepository = operationClaimRepository;
        }
        public async Task NameShouldBeUniqueWhenAdded(string name)
        {
            var operationCalim = await _operationClaimRepository.GetAsync(u => u.Name == name);
            if (operationCalim != null) throw new BusinessException("Name exists");
        }
        public async Task NameShouldBeUniqueWhenUpdated(OperationClaim operationClaim)
        {
            var operationClaim2 = await _operationClaimRepository.GetAsync(u => u.Name == operationClaim.Name);
            if (operationClaim2 != null && operationClaim.Id != operationClaim.Id)
            {
                throw new BusinessException("Name exists");
            }
        }

        public async Task OperationClaimShouldExists(OperationClaim? operationClaim)
        {
            if (operationClaim == null)
            {
                throw new BusinessException("Operation claim does not exist");
            }
        }
    }
}
