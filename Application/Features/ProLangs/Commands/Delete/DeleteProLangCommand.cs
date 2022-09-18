using Application.Features.ProLangs.Constants;
using Application.Features.ProLangs.Dtos;
using Application.Features.ProLangs.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProLangs.Commands.Delete
{
    public class DeleteProLangCommand : IRequest<DeletedProLangDto>
    {
        public int Id { get; set; }

        public class DeleteProLangCommandHandler : IRequestHandler<DeleteProLangCommand, DeletedProLangDto>
        {
            private readonly IMapper _mapper;
            private readonly IProLangRepository _proLangRepository;
            private readonly ProLangBusinessRules _proLangBusinessRules;
            public DeleteProLangCommandHandler(IMapper mapper, IProLangRepository proLangRepository, ProLangBusinessRules proLangBusinessRules)
            {
                _mapper = mapper;
                _proLangRepository = proLangRepository;
                _proLangBusinessRules = proLangBusinessRules;
            }

            public async Task<DeletedProLangDto> Handle(DeleteProLangCommand request, CancellationToken cancellationToken)
            {
                var proLang = await _proLangRepository.GetAsync(p => p.Id == request.Id);
                _proLangBusinessRules.ProLangShouldExists(proLang);

                var deleteProLang = await _proLangRepository.DeleteAsync(proLang);
                return _mapper.Map<DeletedProLangDto>(deleteProLang);
            }
        }
    }
}
