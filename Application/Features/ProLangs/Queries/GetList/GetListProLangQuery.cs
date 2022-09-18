using Application.Features.ProLangs.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProLangs.Queries.GetList
{
    public class GetListProLangQuery : IRequest<ProLangListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListProLangQueryHandler : IRequestHandler<GetListProLangQuery, ProLangListModel>
        {
            private readonly IMapper _mapper;
            private readonly IProLangRepository _proLangRepository;
            public GetListProLangQueryHandler(IMapper mapper, IProLangRepository proLangRepository)
            {
                _mapper = mapper;
                _proLangRepository = proLangRepository;
            }

            public async Task<ProLangListModel> Handle(GetListProLangQuery request, CancellationToken cancellationToken)
            {
                IPaginate<ProLang> proLangs = await _proLangRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);
                return _mapper.Map<ProLangListModel>(proLangs);
            }
        }
    }
}
