using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class ProTechnology:Entity
    {
        public string Name { get; set; }
        public ProLang ProLang { get; set; }
    }
}
