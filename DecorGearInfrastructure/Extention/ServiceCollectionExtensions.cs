using DecorGearApplication.Interface;
using DecorGearApplication.IServices;
using DecorGearApplication.Services;
using DecorGearInfrastructure.Database.AppDbContext;
using DecorGearInfrastructure.implement;
using DecorGearInfrastructure.Implement;
using Microsoft.EntityFrameworkCore;
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
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer("Server=LAPTOP-K61S7AVO;Database=DecorationGear;Trusted_Connection=True;TrustServerCertificate=True");
            });
            //services.AddTransient<IExampleRepository, ExampleRepository>();
            services.AddTransient<IMailingServices, MailingServices>();
            services.AddTransient<IUserRespository, UserRepository>();
            services.AddScoped<IUserServices, UserServices>();
            services.AddTransient<ITokenServices, TokenServices>();
            services.AddTransient<IPasswordServices, PasswordServices>();           
            services.AddScoped<MailingServices>(); 
            services.AddScoped<IFeedBackRespository,FeedBackRepository>();
            services.AddScoped<IFeedbackServices,FeedbackServices>();
            services.AddTransient<IMemberRespository,MemberRepository>();
            services.AddTransient<IMemberServices, MemberServices>();  
            services.AddHttpContextAccessor();

            return services;
        }
    }
}
