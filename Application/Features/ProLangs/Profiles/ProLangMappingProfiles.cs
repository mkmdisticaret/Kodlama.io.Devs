using Application.Features.ProLangs.Commands.Create;
using Application.Features.ProLangs.Commands.Update;
using Application.Features.ProLangs.Dtos;
using Application.Features.ProLangs.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.ProLangs.Profiles
{
    public class ProLangMappingProfiles : Profile
    {
        public ProLangMappingProfiles()
        {
            CreateMap<ProLang, CreatedProLangDto>().ReverseMap();
            CreateMap<ProLang, DeletedProLangDto>().ReverseMap();
            CreateMap<ProLang, UpdatedProLangDto>().ReverseMap();
            CreateMap<ProLang, GetByIdProLangDto>().ReverseMap();
            CreateMap<ProLang, GetListProLangDto>().ReverseMap();
            CreateMap<ProLang, CreateProLangCommand>().ReverseMap();
            CreateMap<ProLang, UpdateProLangCommand>().ReverseMap();
            CreateMap<IPaginate<ProLang>, ProLangListModel>();
        }
    }
}
