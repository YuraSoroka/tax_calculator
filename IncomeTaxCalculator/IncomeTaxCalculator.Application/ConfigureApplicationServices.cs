using Microsoft.Extensions.DependencyInjection;

namespace IncomeTaxCalculator.Application
{
    public static class ConfigureApplicationServices
    {
        public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
        {
            return services;
        }
    }
}
