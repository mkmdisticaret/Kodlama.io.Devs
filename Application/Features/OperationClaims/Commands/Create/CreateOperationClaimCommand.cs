using Application.Features.OperationClaims.Dtos;
using Application.Features.OperationClaims.Rules;
using Application.Services.Repositories;
using MediatR;

namespace Application.Features.OperationClaims.Commands.Create
{
    public class CreateOperationClaimCommand : IRequest<OperationClaimDto>
    {
        public string Name { get; set; }
        public class CreateOperationClaimCommandHandler : IRequestHandler<CreateOperationClaimCommand, OperationClaimDto>
        {
            private readonly IOperationClaimRepository _operationClaimRepository;
            private readonly OperationClaimBusinessRules _operationClaimBusinessRules;

            public CreateOperationClaimCommandHandler(IOperationClaimRepository operationClaimRepository, OperationClaimBusinessRules operationClaimBusinessRules)
            {
                _operationClaimRepository = operationClaimRepository;
                _operationClaimBusinessRules = operationClaimBusinessRules;
            }

            public async Task<OperationClaimDto> Handle(CreateOperationClaimCommand request, CancellationToken cancellationToken)
            {
                await _operationClaimBusinessRules.NameShouldBeUniqueWhenAdded(request.Name);
                var createdOperationClaim = await _operationClaimRepository.AddAsync(new Core.Security.Entities.OperationClaim { Name = request.Name });
                return new OperationClaimDto { Id = createdOperationClaim.Id, Name = createdOperationClaim.Name };
            }
        }
    }
}
