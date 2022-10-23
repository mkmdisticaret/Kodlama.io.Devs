using Application.Features.OperationClaims.Dtos;
using Application.Features.OperationClaims.Rules;
using Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaims.Commands.Update
{
    public class UpdateOperationClaimCommand:IRequest<OperationClaimDto>
    {
        public int OperationClaimId { get; set; }
        public string Name { get; set; }

        public class UpdateOperationClaimCommandHandler : IRequestHandler<UpdateOperationClaimCommand, OperationClaimDto>
        {
            private readonly IOperationClaimRepository _operationClaimRepository;
            private readonly OperationClaimBusinessRules _operationClaimBusinessRules;

            public UpdateOperationClaimCommandHandler(IOperationClaimRepository operationClaimRepository, OperationClaimBusinessRules operationClaimBusinessRules)
            {
                _operationClaimRepository = operationClaimRepository;
                _operationClaimBusinessRules = operationClaimBusinessRules;
            }

            public async Task<OperationClaimDto> Handle(UpdateOperationClaimCommand request, CancellationToken cancellationToken)
            {
                var operationClaim = await _operationClaimRepository.GetAsync(o => o.Id == request.OperationClaimId);
                await _operationClaimBusinessRules.OperationClaimShouldExists(operationClaim);

                await _operationClaimBusinessRules.NameShouldBeUniqueWhenUpdated(operationClaim);
                operationClaim.Name = request.Name;
                var updatedOperationClaim = await _operationClaimRepository.UpdateAsync(operationClaim);
                return new OperationClaimDto { Name = updatedOperationClaim.Name, Id = updatedOperationClaim.Id };
            }
        }
    }
}
