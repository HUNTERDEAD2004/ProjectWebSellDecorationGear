using DecorGearApplication.Interface;
using DecorGearInfrastructure.Database.AppDbContext;
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
            services.AddScoped<IImageListRespository, ImageListRespository>();
            services.AddScoped<IProductRespository, ProductRespository>();
            services.AddScoped<ICategoryRespository, CategoryRespository>();
            services.AddScoped<ISubCategoryRespository, SubCategoryRespository>();
            services.AddScoped<IBrandRespository, BrandRespository>();
            services.AddScoped<IKeyboardRespository, KeyboardRespository>();
            services.AddScoped<IMouseRespository, MouseRespository>();

            services.AddTransient<AppDbContext>();

            return services;
        }
    }
}
