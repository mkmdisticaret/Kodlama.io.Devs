using Application.Features.UserOperationClaims.Dtos;
using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;

namespace Application.Features.UserOperationClaims.Profiles
{
    public class UserOperationClaimProfiles : Profile
    {
        public UserOperationClaimProfiles()
        {
            CreateMap<UserOperationClaim, UserOperationClaimDto>().ReverseMap();
        }
    }
}
