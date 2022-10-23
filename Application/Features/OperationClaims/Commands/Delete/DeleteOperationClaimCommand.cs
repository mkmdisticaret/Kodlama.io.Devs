using Application.Features.OperationClaims.Dtos;
using Application.Features.OperationClaims.Rules;
using Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaims.Commands.Delete
{
    public class DeleteOperationClaimCommand:IRequest<OperationClaimDto>
    {
        public int OperationClaimId { get; set; }
        public class DeleteOperationClaimCommandHandler : IRequestHandler<DeleteOperationClaimCommand, OperationClaimDto>
        {
            private readonly IOperationClaimRepository _operationClaimRepository;
            private readonly OperationClaimBusinessRules _operationClaimBusinessRules;

            public DeleteOperationClaimCommandHandler(IOperationClaimRepository operationClaimRepository, OperationClaimBusinessRules operationClaimBusinessRules)
            {
                _operationClaimRepository = operationClaimRepository;
                _operationClaimBusinessRules = operationClaimBusinessRules;
            }

            public async Task<OperationClaimDto> Handle(DeleteOperationClaimCommand request, CancellationToken cancellationToken)
            {
                var operationClaim = await _operationClaimRepository.GetAsync(o => o.Id == request.OperationClaimId);
                await _operationClaimBusinessRules.OperationClaimShouldExists(operationClaim);
                var deleteOperationClaim = await _operationClaimRepository.DeleteAsync(operationClaim);
                return new OperationClaimDto { Id = deleteOperationClaim.Id, Name = deleteOperationClaim.Name };
            }
        }
    }
}
