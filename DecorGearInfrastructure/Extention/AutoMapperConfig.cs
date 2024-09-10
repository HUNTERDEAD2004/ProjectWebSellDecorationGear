using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using DecorGearApplication.DataTransferObj.Member;
using DecorGearDomain.Data.Entities;

namespace DecorGearInfrastructure.Extention
{
    public static class AutoMapperConfig
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
