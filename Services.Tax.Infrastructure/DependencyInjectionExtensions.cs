using Microsoft.Extensions.DependencyInjection;
using Services.Tax.Infrastructure.Interfaces;
using Services.Tax.Infrastructure.Utils;
using System.Reflection;

namespace Services.Tax.Infrastructure
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection RegisterInfrastructure(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())
            );

            services.AddSingleton<ITaxCalculator, IncomeTaxCalculator>();

            return services;
        }
    }
}
