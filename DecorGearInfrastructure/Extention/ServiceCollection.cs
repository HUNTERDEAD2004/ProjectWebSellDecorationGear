
using DecorGearApplication.Interface;
using DecorGearInfrastructure.Database.AppDbContext;
using DecorGearInfrastructure.Extention.AutoMapper;
using DecorGearInfrastructure.Implement;
using Microsoft.EntityFrameworkCore;
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
    public static class ServiceCollection
    {
        public static IServiceCollection AddEventBus(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer("Server=LAPTOP-K61S7AVO;Database=DecorationGear;Trusted_Connection=True;TrustServerCertificate=True");
            });
            // Đăng ký các repository với vòng đời Transient
            services.AddTransient<IExampleServices, ExampleRepository>();
            services.AddTransient<IMemberService, MemberRepository>();            




            return services;
        }

      
    }
}
