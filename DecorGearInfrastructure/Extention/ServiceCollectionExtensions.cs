using DecorGearApplication.Interface;
using DecorGearInfrastructure.Database.AppDbContext;
using DecorGearInfrastructure.implement;
using DecorGearInfrastructure.Implement;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearInfrastructure.Extention
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEventBus(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddTransient<AppDbContext>();

            return services;
        }
    }
}
