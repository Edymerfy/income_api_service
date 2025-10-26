using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Services.Tax.Api
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection RegisterWebApi(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Description = "API for calculating income tax in the UK",
                    License = new OpenApiLicense
                    {
                        Name = "MIT License",
                        Url = new Uri("https://opensource.org/licenses/MIT")
                    }
                });

                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });

            return services;
        }
    }
}
