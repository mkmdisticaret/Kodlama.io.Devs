using Application.Features.ProTecnologies.Dtos;
using Application.Features.ProTecnologies.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProTecnologies.Queries
{
    public class GetListProTechnologyQuery:IRequest<ProTechnologyListModel>
    {
        public PageRequest  PageRequest{ get; set; }

        public class GetListProTechnologyQueryHandler : IRequestHandler<GetListProTechnologyQuery, ProTechnologyListModel>
        {
            private readonly IProTechnologyRepository _proTechnologyRepository;
            private readonly IMapper _mapper;

            public GetListProTechnologyQueryHandler(IProTechnologyRepository proTechnologyRepository, IMapper mapper)
            {
                _proTechnologyRepository = proTechnologyRepository;
                _mapper = mapper;
            }

            public async Task<ProTechnologyListModel> Handle(GetListProTechnologyQuery request, CancellationToken cancellationToken)
            {
               IPaginate<ProTechnology> list = await  _proTechnologyRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);
                return _mapper.Map<ProTechnologyListModel>(list);
            }
        }
    }
}
