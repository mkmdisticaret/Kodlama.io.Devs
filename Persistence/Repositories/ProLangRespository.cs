using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class ProLangRespository : EfRepositoryBase<ProLang, BaseDbContext>, IProLangRepository
    {
        public ProLangRespository(BaseDbContext context) : base(context)
        {

        }
    }
}
