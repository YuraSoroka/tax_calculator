using FluentValidation;
using IncomeTaxCalculator.Application.Commands.Tax;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace IncomeTaxCalculator.Application
{
    public static class ConfigureApplicationServices
    {
        public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            return services;
        }
    }
}
