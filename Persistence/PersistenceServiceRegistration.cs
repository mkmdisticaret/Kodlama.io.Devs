using Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;

namespace Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BaseDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("KodlamaIoDevsConnectionString")));
            services.AddScoped<IOperationClaimRepository, OperationClaimRepository>();
            services.AddScoped<IProLangRepository, ProLangRespository>();
            services.AddScoped<IProTechnologyRepository, ProTechnologyRepository>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddScoped<IUserOperationClaimRepository, UserOperationRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IDeveloperRepository, DeveloperRepository>();
            return services;
        }
    }
}
