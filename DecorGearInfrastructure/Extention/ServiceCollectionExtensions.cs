using DecorGearApplication.Interface;
using DecorGearApplication.IServices;
using DecorGearApplication.Services;
using DecorGearInfrastructure.Database.AppDbContext;
using DecorGearInfrastructure.implement;
using DecorGearInfrastructure.Implement;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DecorGearInfrastructure.Extention
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEventBus(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddTransient<IExampleRepository, ExampleRepository>();
            services.AddTransient<IMailingServices, MailingServices>();
            services.AddTransient<IUserRespository, UserRepository>();
            services.AddScoped<IUserServices, UserServices>();
            services.AddTransient<ITokenServices, TokenServices>();
            services.AddTransient<IPasswordServices, PasswordServices>();
            services.AddScoped<MailingServices>();
            services.AddScoped<IFeedBackRespository, FeedBackRepository>();
            services.AddScoped<IFeedbackServices, FeedbackServices>();
            services.AddTransient<IMemberRespository, MemberRepository>();
            services.AddTransient<IMemberServices, MemberServices>();
            services.AddTransient<CartService>();
            services.AddTransient<HomeRepository>();
            services.AddTransient<ICartRespository, CartRepository>();
            services.AddHttpContextAccessor();

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
