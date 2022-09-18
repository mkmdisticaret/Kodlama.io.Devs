using Application.Features.ProLangs.Dtos;
using Application.Features.ProLangs.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProLangs.Commands.Create
{
    public class CreateProLangCommand : IRequest<CreatedProLangDto>
    {
        public string Name { get; set; }

        public class CreateProLangCommandHandler : IRequestHandler<CreateProLangCommand, CreatedProLangDto>
        {
            private readonly IMapper _mapper;
            private readonly ProLangBusinessRules _proLangBusinessRules;
            private readonly IProLangRepository _proLangRepository;

            public CreateProLangCommandHandler(IMapper mapper, ProLangBusinessRules proLangBusinessRules, IProLangRepository proLangRepository)
            {
                _mapper = mapper;
                _proLangBusinessRules = proLangBusinessRules;
                _proLangRepository = proLangRepository;
            }

            public async Task<CreatedProLangDto> Handle(CreateProLangCommand request, CancellationToken cancellationToken)
            {
                await _proLangBusinessRules.ProLangNameCanNotBeDuplicate(request.Name);

                ProLang mappedProLang = _mapper.Map<ProLang>(request);
                ProLang createdProLang = await _proLangRepository.AddAsync(mappedProLang);
                return _mapper.Map<CreatedProLangDto>(createdProLang);
            }
        }
    }
}
