using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Domain.Entities
{
    public class Developer : Entity
    {
        public int UserId { get; set; }
        public string GitHubAddres { get; set; }

        public User User { get; set; }
    }
}
