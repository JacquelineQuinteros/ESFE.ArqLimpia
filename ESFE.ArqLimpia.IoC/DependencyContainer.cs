using ESFE.ArqLimpia.DAL;
using ESFE.ArqLimpia.BL;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace ESFE.ArqLimpia.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddESFEDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDALDependencies(configuration);
            services.AddBLDependencies();
            return services;
        }

    }
}