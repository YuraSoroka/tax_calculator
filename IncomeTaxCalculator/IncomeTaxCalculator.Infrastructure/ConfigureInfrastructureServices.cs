using IncomeTaxCalculator.Application.Common.Interfaces;
using IncomeTaxCalculator.Infrastructure.Data;
using IncomeTaxCalculator.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace IncomeTaxCalculator.Infrastructure
{
    public static class ConfigureInfrastructureServices
    {
        public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IAnnualTaxCalculator, TaxCalculatorService>();
            services.AddScoped<ITaxHistoryWriter, TaxCalculationHistoryService>();
            services.AddDbContext<ApplicationDbContext>();
            services.AddSingleton<ApplicationDbContext>();
            return services;
        }
    }
}
