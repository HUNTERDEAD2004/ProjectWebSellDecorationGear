using DecorGearApplication.Interface;
using DecorGearInfrastructure.Database.AppDbContext;
using DecorGearInfrastructure.implement;
using DecorGearInfrastructure.Implement;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DecorGearApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<AppDbContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnect"));
            });
            builder.Services.AddScoped<IOderRespository,  OrderRepository>();
            builder.Services.AddScoped<ICartDetailRespository, CartRepository>();
            builder.Services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
            builder.Services.AddScoped<IVoucherRespository, VoucherRepository>();
            var app = builder.Build();

            

            
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();


            // Map controllers
            app.MapControllers();

            app.Run();
        }
    }
}
