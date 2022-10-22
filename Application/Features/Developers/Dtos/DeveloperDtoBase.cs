using Core.Security.Entities;

namespace Application.Features.Developers.Dtos
{
    public abstract class DeveloperDtoBase
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string GitHubAddress { get; set; }
    }
}
