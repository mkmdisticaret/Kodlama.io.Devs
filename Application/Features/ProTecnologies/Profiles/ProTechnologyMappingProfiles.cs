using Application.Features.ProTecnologies.Dtos;
using Application.Features.ProTecnologies.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.ProTecnologies.Profiles
{
    public class ProTechnologyMappingProfiles : Profile
    {
        public ProTechnologyMappingProfiles()
        {
            CreateMap<ProTechnology, GetListProTechnologyDto>();
            CreateMap<IPaginate<ProTechnology>, ProTechnologyListModel>();
        }
    }
}
