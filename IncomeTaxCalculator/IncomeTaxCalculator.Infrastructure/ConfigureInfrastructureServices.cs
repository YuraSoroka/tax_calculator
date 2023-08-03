using IncomeTaxCalculator.Application.Common.Interfaces;
using IncomeTaxCalculator.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace IncomeTaxCalculator.Infrastructure
{
    public static class ConfigureInfrastructureServices
    {
        public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IAnnualTaxCalculator, TaxCalculatorService>();
            services.AddScoped<IMonthlyTaxCalculator, TaxCalculatorService>();
            return services;
        }
    }
}
