using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sat.Recruitment.Core.BussinesServices.User;
using Sat.Recruitment.Core.Helpers.AppSettings;
using Sat.Recruitment.Core.Interfaces.Services;
using Sat.Recruitment.Core.Utils.Exceptions;

namespace Sat.Recruitment.Core
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddCore(this IServiceCollection services, IConfiguration config)
        {
            /* Options */
            services.Configure<AppSettings>(config.GetSection("AppSettings"));

            /* IOC */
            services.AddScoped<IUserService, UserService>();

            /* IOC Injection */
            services.AddConfigurationExceptions(config);

            return services;
        }

    }
}

