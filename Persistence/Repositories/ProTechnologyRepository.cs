using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class ProTechnologyRepository : EfRepositoryBase<ProTechnology, BaseDbContext>, IProTechnologyRepository
    {
        public ProTechnologyRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
