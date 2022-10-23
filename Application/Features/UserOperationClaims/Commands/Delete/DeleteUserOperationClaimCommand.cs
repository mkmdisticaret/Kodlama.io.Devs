using Application.Features.UserOperationClaims.Dtos;
using Application.Features.UserOperationClaims.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.UserOperationClaims.Commands.Delete
{
    public class DeleteUserOperationClaimCommand : IRequest<UserOperationClaimDto>
    {
        public int Id { get; set; }
        public class DeleteUserOperationClaimCommandHandler : IRequestHandler<DeleteUserOperationClaimCommand, UserOperationClaimDto>
        {

            private readonly IUserOperationClaimRepository _userOperationClaimRepository;
            private readonly UserOperationClaimBusinessRules _userOperationClaimBusinessRules;
            private readonly IMapper _mapper;

            public DeleteUserOperationClaimCommandHandler(IUserOperationClaimRepository userOperationClaimRepository, UserOperationClaimBusinessRules userOperationClaimBusinessRules, IMapper mapper)
            {
                _userOperationClaimRepository = userOperationClaimRepository;
                _userOperationClaimBusinessRules = userOperationClaimBusinessRules;
                _mapper = mapper;
            }

            public async Task<UserOperationClaimDto> Handle(DeleteUserOperationClaimCommand request, CancellationToken cancellationToken)
            {
                var userOperationClaim = await _userOperationClaimRepository.GetAsync(u => u.Id == request.Id);

                await _userOperationClaimBusinessRules.UserOperationClaimShouldBeExist(userOperationClaim);

                var deleteUserOperationClaim = await _userOperationClaimRepository.DeleteAsync(userOperationClaim);

                return _mapper.Map<UserOperationClaimDto>(deleteUserOperationClaim);
            }
        }
    }
}
