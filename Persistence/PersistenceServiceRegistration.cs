﻿using Application.Services.Repositories;
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
            services.AddScoped<IProLangRepository, ProLangRespository>();
            return services;
        }
    }
}