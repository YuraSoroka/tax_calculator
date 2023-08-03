using IncomeTaxCalculator.Application.Common.Interfaces;
using IncomeTaxCalculator.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace IncomeTaxCalculator.Infrastructure
{
    public static class ConfigureInfrastructureServices
    {
        public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<ITaxCalculator, TaxCalculatorService>();
            return services;
        }
    }
}
