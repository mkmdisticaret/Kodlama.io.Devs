using Application.Features.UserOperationClaims.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.UserOperationClaims.Queries
{
    public class GetListUserOperationClaimQuery : IRequest<List<UserOperationClaimDto>>
    {
        public int UserId { get; set; }

        public class GetListUserOperationClaimQueryHandler : IRequestHandler<GetListUserOperationClaimQuery, List<UserOperationClaimDto>>
        {
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;
            private readonly IMapper _mapper;

            public GetListUserOperationClaimQueryHandler(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper)
            {
                _userOperationClaimRepository = userOperationClaimRepository;
                _mapper = mapper;
            }

            public async Task<List<UserOperationClaimDto>> Handle(GetListUserOperationClaimQuery request, CancellationToken cancellationToken)
            {
                var result = await _userOperationClaimRepository.GetListAsync(u => u.UserId == request.UserId);
                return _mapper.Map<List<UserOperationClaimDto>>(result.Items);
            }
        }
    }
}
