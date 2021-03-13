using BusinessLayer;
using BusinessLayer.interfaces;
using Microsoft.Extensions.DependencyInjection;
using powerplant_coding_challenge_api.Logging;
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
            ConfigureBusinessSevices(services);
            ConfigureControllers(services);
            ConfigureSingleton(services);
        }

        public static void ConfigureBusinessSevices(this IServiceCollection services)
        {
            services.AddScoped<IPowerplantManager, PowerplantManager>();
            services.AddScoped<IProductionPlanManager, ProductionPlanManager>();
        }

        public static void ConfigureControllers(this IServiceCollection services)
        {
            services.AddControllers();
        }

        public static void ConfigureSingleton(this IServiceCollection services)
        {
            services.AddSingleton<ILog, LoggerNLog>();
        }

    }
}
