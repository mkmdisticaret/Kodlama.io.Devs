using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class ProTechnology:Entity
    {
        public int ProLangId { get; set; }
        public string Name { get; set; }
        public ProLang ProLang { get; set; }
    }
}
