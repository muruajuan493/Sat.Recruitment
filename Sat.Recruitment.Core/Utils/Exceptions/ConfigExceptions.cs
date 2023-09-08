using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sat.Recruitment.Core.Utils.Exceptions.Services;

namespace Sat.Recruitment.Core.Utils.Exceptions
{
    internal static class ConfigExceptions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <param name="config">The <see cref="IConfiguration"/></param>
        /// <returns></returns>
        public static IServiceCollection AddConfigurationExceptions(this IServiceCollection services, IConfiguration config)
        {
            // Services
            services.AddScoped<IExceptionService, ExceptionService>();

            return services;
        }

        /// <summary>
        /// Agrega los middlewares de la capa transversal.
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder"/></param>
        /// <returns>The <see cref="IApplicationBuilder"/></returns>
        public static IApplicationBuilder AddConfigurationExceptions(this IApplicationBuilder app)
        {
            return app;
        }
    }
}
