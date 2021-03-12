using BusinessLayer;
using BusinessLayer.interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace powerplant_coding_challenge_api.Configuration
{
    public static class DependencyManager
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            ConfigureServices(services);
            ConfigureControllers(services);
        }

        public static void ConfigureBusinessSevices(this IServiceCollection services)
        {
            services.AddScoped<IPowerCalculator, PowerCalculator>();
        }

        public static void ConfigureControllers(this IServiceCollection services)
        {
            services.AddControllers();
        }

    }
}
