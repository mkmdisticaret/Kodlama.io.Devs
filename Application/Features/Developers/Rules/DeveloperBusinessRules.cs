using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;

namespace Application.Features.Developers.Rules
{
    public class DeveloperBusinessRules
    {
        private readonly IUserRepository _userRepository;
        private readonly IDeveloperRepository _developerRepository;

        public DeveloperBusinessRules(IUserRepository userRepository, IDeveloperRepository developerRepository)
        {
            _userRepository = userRepository;
            _developerRepository = developerRepository;
        }

        public async Task UserMustExist(int userId)
        {
            var user = await _userRepository.GetAsync(u => u.Id == userId);
            if (user == null)
            {
                throw new BusinessException("User does not exist");
            }
        }
        public async Task DeveloperMustExist(Developer developer)
        {
            if (developer == null) 
                throw new BusinessException("Developer  does not exist");
        }
    }
}
