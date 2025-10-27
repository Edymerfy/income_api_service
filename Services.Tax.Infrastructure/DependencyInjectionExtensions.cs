using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Services.Tax.Infrastructure.DataAccess;
using Services.Tax.Infrastructure.Interfaces;
using Services.Tax.Infrastructure.Security;
using Services.Tax.Infrastructure.Utils;
using System.Reflection;

namespace Services.Tax.Infrastructure
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection RegisterInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseInMemoryDatabase("IMDB");
            });

            services.AddScoped<IPeriodRepository, PeriodRepository>();

            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())
            );

            services.AddScoped<ITaxCalculator, IncomeTaxCalculator>();

            var strategyType = typeof(ITaxBandStrategy);
            var assembly = typeof(ITaxBandStrategy).Assembly;

            foreach (var type in assembly.GetTypes()
                .Where(t => strategyType.IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract))
            {
                services.AddScoped(strategyType, type);
            }


            services.AddSingleton<JwtTokenManager>();

            return services;
        }
    }
}
