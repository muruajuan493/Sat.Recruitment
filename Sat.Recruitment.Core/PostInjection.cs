using Microsoft.Extensions.DependencyInjection;

namespace Sat.Recruitment.Core
{
    public class PostInjection
    {
        public static class Injector
        {
            static IServiceProvider _provider;

            public static void GenerateProvider(IServiceCollection serviceCollection)
            {
                _provider = serviceCollection.BuildServiceProvider();
            }

            public static T GetService<T>()
            {
                return _provider.GetService<T>();
            }
        }
    }
}
