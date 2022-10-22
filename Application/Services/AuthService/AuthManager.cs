using Application.Services.Repositories;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Core.Security.JWT;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.AuthService
{
    public class AuthManager : IAuthService
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly ITokenHelper _tokenHelper;
        private readonly IRefreshTokenRepository _refreshTokenRepository;

        public AuthManager(IUserOperationClaimRepository userOperationClaimRepository, ITokenHelper tokenHelper, IRefreshTokenRepository refreshTokenRepository)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _tokenHelper = tokenHelper;
            _refreshTokenRepository = refreshTokenRepository;
        }

        public Task<RefreshToken> AddRefreshToken(RefreshToken refreshToken)
        {
            return _refreshTokenRepository.AddAsync(refreshToken);
        }

        public async Task<AccessToken> CreateAccessToken(User user)
        {
            IPaginate<UserOperationClaim> userOperationClaims = await _userOperationClaimRepository.GetListAsync(u => u.UserId == user.Id,
                include: u => u.Include(u => u.OperationClaim));

            IList<OperationClaim> operationClaims = userOperationClaims.Items.Select(u => u.OperationClaim).ToList();

            return await Task.FromResult(_tokenHelper.CreateToken(user, operationClaims));
        }

        public async Task<RefreshToken> CreateRefreshToken(User user, string ipAddress)
        {
            return await Task.FromResult(_tokenHelper.CreateRefreshToken(user, ipAddress));
        }
    }
}
