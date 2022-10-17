using Application.Features.ProLangs.Queries.GetById;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProTecnologies.Rules
{
    public class ProTechnologyBusinessRules
    {
        private readonly IProTechnologyRepository _proTechnologyRepository;
        private readonly IMediator _mediator;

        public ProTechnologyBusinessRules(IProTechnologyRepository proTechnologyRepository, IMediator mediator)
        {
            _proTechnologyRepository = proTechnologyRepository;
            _mediator = mediator;
        }

        public async Task ProTechnologyNameCanNotBeDuplicateWhenAdded(string name)
        {
            var proTechnology = await _proTechnologyRepository.GetAsync(p => p.Name == name);
            if (proTechnology != null && name == proTechnology.Name)
            {
                throw new BusinessException("Program technology is exists.");
            }
        }

        public async Task ProTechnologyNameCanNotBeDuplicateWhenUpdated(ProTechnology proTechnology)
        {
            var proTechnologyAtDb = await _proTechnologyRepository.GetAsync(p => p.Name == proTechnology.Name);
            if (proTechnologyAtDb != null && proTechnologyAtDb.Id != proTechnology.Id)
            {
                throw new BusinessException("Program technology  is exists.");
            }
        }
        public async Task ProLangShouldExist(int proLangId)
        {
            var proLangDto = await _mediator.Send(new GetByIdProLangQuery { Id = proLangId });
            if (proLangDto == null)
            {
                throw new BusinessException("Program language does not exists.");
            }
        }
    }
}
