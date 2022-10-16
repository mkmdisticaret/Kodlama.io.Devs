using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories
{
    public interface IProTechnologyRepository : IAsyncRepository<ProTechnology>, IRepository<ProTechnology>
    {

    }
}
