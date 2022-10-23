using Application.Features.ProLangs.Constants;
using Application.Features.ProLangs.Dtos;
using Application.Features.ProLangs.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProLangs.Commands.Update
{
    public class UpdateProLangCommand :IRequest<UpdatedProLangDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class UpdateProLangCommandHandler : IRequestHandler<UpdateProLangCommand, UpdatedProLangDto>
        {
            private readonly IMapper _mapper;
            private readonly IProLangRepository _proLangRepository;
            private readonly ProLangBusinessRules _proLangBusinessRules;
            public UpdateProLangCommandHandler(IMapper mapper, IProLangRepository proLangRepository, ProLangBusinessRules proLangBusinessRules)
            {
                _mapper = mapper;
                _proLangRepository = proLangRepository;
                _proLangBusinessRules = proLangBusinessRules;   
            }

            public async Task<UpdatedProLangDto> Handle(UpdateProLangCommand request, CancellationToken cancellationToken)
            {
                var proLang = await _proLangRepository.GetAsync(p => p.Id == request.Id);
                
                _proLangBusinessRules.ProLangShouldExists(proLang);
                await _proLangBusinessRules.ProLangNameCanNotBeDuplicateWhenUpdated(proLang);

                _mapper.Map( request,proLang);
                var updatedProLang= await _proLangRepository.UpdateAsync(proLang);
                return _mapper.Map<UpdatedProLangDto>(updatedProLang);
            }
        }
    }
}
