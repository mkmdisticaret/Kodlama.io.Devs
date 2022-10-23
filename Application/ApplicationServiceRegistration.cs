using Application.Features.Auths.Rules;
using Application.Features.Developers.Rules;
using Application.Features.OperationClaims.Rules;
using Application.Features.ProLangs.Rules;
using Application.Features.ProTecnologies.Rules;
using Application.Features.UserOperationClaims.Rules;
using Application.Services.AuthService;
using Core.Application.Pipelines.Validation;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddScoped<ProLangBusinessRules>();
            services.AddScoped<ProTechnologyBusinessRules>();
            services.AddScoped<AuthBusinessRules>();
            services.AddScoped<DeveloperBusinessRules>();
            services.AddScoped<OperationClaimBusinessRules>();
            services.AddScoped<UserOperationClaimBusinessRules>();

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            services.AddScoped<IAuthService, AuthManager>();
            return services;
        }
    }
}
