using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class ProLang : Entity
    {
        public string Name { get; set; }

        public ICollection<ProTechnology> ProTechnologies { get; set; }
    }
}
