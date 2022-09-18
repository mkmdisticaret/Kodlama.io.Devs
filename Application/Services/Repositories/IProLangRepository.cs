using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories
{
    public interface IProLangRepository : IAsyncRepository<ProLang>,IRepository<ProLang>
    {
    }
}
