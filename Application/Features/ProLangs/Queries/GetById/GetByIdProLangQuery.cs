using Application.Features.ProLangs.Dtos;
using Application.Features.ProLangs.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProLangs.Queries.GetById
{
    public class GetByIdProLangQuery:IRequest<GetByIdProLangDto>
    {
        public int Id { get; set; }

        public class GetByIdProLangQueryHandler : IRequestHandler<GetByIdProLangQuery, GetByIdProLangDto>
        {
            private readonly IMapper _mapper;
            private readonly IProLangRepository _proLangRepository;
            private readonly ProLangBusinessRules _proLangBusinessRules;
            public GetByIdProLangQueryHandler(IMapper mapper, IProLangRepository proLangRepository,ProLangBusinessRules proLangBusinessRules)
            {
                _mapper = mapper;
                _proLangRepository = proLangRepository;
                _proLangBusinessRules = proLangBusinessRules;
            }

            public async Task<GetByIdProLangDto> Handle(GetByIdProLangQuery request, CancellationToken cancellationToken)
            {
                var proLang = await _proLangRepository.GetAsync(p => p.Id == request.Id);

                _proLangBusinessRules.ProLangShouldExists(proLang);

                return _mapper.Map<GetByIdProLangDto>(proLang);
            }
        }
    }
}
