using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;

namespace Application.Features.UserOperationClaims.Rules
{
    public class UserOperationClaimBusinessRules
    {
        private readonly IUserRepository _userRepository;
        private readonly IOperationClaimRepository _operationClaimRepository;


        public UserOperationClaimBusinessRules(IUserRepository userRepository, IOperationClaimRepository operationClaimRepository)
        {
            _userRepository = userRepository;
            _operationClaimRepository = operationClaimRepository;
        }

        public async Task UserShouldBeExist(int userId)
        {
            var user =await _userRepository.GetAsync(u => u.Id == userId);
            if (user == null)
            {
                throw new BusinessException("User does not exist");
            }
        }

        public async Task OperationClaimShouldBeExist(int operationClaimId)
        {
            var operationClaim =await _operationClaimRepository.GetAsync(u => u.Id == operationClaimId);
            if (operationClaim == null)
            {
                throw new BusinessException("Operation claim does not exist");
            }
        }

        public async Task UserOperationClaimShouldBeExist(UserOperationClaim userOperationClaim)
        {
            if (userOperationClaim == null)
            {
                throw new BusinessException("User operation claim does not exist");
            }
        }
    }
}
