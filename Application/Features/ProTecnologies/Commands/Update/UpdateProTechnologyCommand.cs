using Application.Features.ProTecnologies.Dtos;
using Application.Features.ProTecnologies.Rules;
using Application.Services.Repositories;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProTecnologies.Commands.Update
{
    public class UpdateProTechnologyCommand : IRequest<UpdatedProTechnologyDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProLangId { get; set; }

        public class UpdateProTechnologyCommandHandler : IRequestHandler<UpdateProTechnologyCommand, UpdatedProTechnologyDto>
        {
            private readonly IProTechnologyRepository _proTechnologyRepository;
            private readonly ProTechnologyBusinessRules _proTechnologyBusinessRules;

            public UpdateProTechnologyCommandHandler(IProTechnologyRepository proTechnologyRepository, ProTechnologyBusinessRules proTechnologyBusinessRules)
            {
                _proTechnologyRepository = proTechnologyRepository;
                _proTechnologyBusinessRules = proTechnologyBusinessRules;
            }

            public async Task<UpdatedProTechnologyDto> Handle(UpdateProTechnologyCommand request, CancellationToken cancellationToken)
            {
                await _proTechnologyBusinessRules.ProLangShouldExist(request.ProLangId);

                var proTechnology = await _proTechnologyRepository.GetAsync(p => p.Id == request.Id);

                proTechnology.ProLangId = request.ProLangId;
                proTechnology.Name = request.Name;

                await _proTechnologyBusinessRules.ProTechnologyNameCanNotBeDuplicateWhenUpdated(proTechnology);

                var updatedProtechnology = await _proTechnologyRepository.UpdateAsync(proTechnology);
                return new UpdatedProTechnologyDto { Id = updatedProtechnology.Id, Name = updatedProtechnology.Name };
            }
        }
    }
}
