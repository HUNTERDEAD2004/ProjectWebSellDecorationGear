using AutoMapper.Extensions.ExpressionMapping;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearInfrastructure.Extention
{
    public static class AutoMapperConfiguration
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            using (var serviceProvider = services.BuildServiceProvider())
            {
                var executingAssembly = Assembly.GetExecutingAssembly();
                var entryAssembly = Assembly.GetEntryAssembly();
                var configuration = serviceProvider.GetRequiredService<IConfiguration>();
                services.AddAutoMapper(configuration => { configuration.AddExpressionMapping(); }, executingAssembly,
                    entryAssembly);
                return services;
            }
        }
    }
}
