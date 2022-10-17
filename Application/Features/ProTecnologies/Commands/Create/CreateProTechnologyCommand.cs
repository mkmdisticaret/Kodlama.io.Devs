using Application.Features.ProTecnologies.Dtos;
using Application.Features.ProTecnologies.Rules;
using Application.Services.Repositories;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProTecnologies.Commands.Create
{
    public class CreateProTechnologyCommand : IRequest<CreatedProTechnologyDto>
    {
        public string Name { get; set; }
        public int ProTechnologyId { get; set; }
        public class CreateProTechnologyCommandHandler : IRequestHandler<CreateProTechnologyCommand, CreatedProTechnologyDto>
        {
            private readonly IProTechnologyRepository _proTechnologyRepository;
            private readonly ProTechnologyBusinessRules _proTechnlogyBusinessRules;

            public CreateProTechnologyCommandHandler(IProTechnologyRepository proTechnologyRepository, ProTechnologyBusinessRules proTechnlogyBusinessRules)
            {
                _proTechnologyRepository = proTechnologyRepository;
                _proTechnlogyBusinessRules = proTechnlogyBusinessRules;
            }

            public async Task<CreatedProTechnologyDto> Handle(CreateProTechnologyCommand request, CancellationToken cancellationToken)
            {
                await _proTechnlogyBusinessRules.ProTechnologyNameCanNotBeDuplicateWhenAdded(request.Name);
                await _proTechnlogyBusinessRules.ProLangShouldExist(request.ProTechnologyId);

                var addedProTechnology = await _proTechnologyRepository.AddAsync(new ProTechnology { Name = request.Name, ProLangId = request.ProTechnologyId });

                return new CreatedProTechnologyDto { Id = addedProTechnology.Id, Name = addedProTechnology.Name };
            }
        }
    }
}
