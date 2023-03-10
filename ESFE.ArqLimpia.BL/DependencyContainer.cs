using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESFE.ArqLimpia.BL.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ESFE.ArqLimpia.BL
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddBLDependencies(this IServiceCollection services)
        {
            services.AddTransient<IUserBL, UserBL>();
            return services;
        }
    }
}
