using Microsoft.Extensions.DependencyInjection;
using Sat.Recruitment.Core.Interfaces.Repositories;
using Sat.Recruitment.Infrastructure.Repositories;

namespace Sat.Recruitment.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            return services;
        }
    }
}

