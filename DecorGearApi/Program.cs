
using DecorGearApplication.Interface;
using DecorGearDomain.Data.Entities;
using DecorGearInfrastructure.Database.AppDbContext;
using DecorGearInfrastructure.Extention;
using DecorGearInfrastructure.Implement;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace DecorGearApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var MyAllowSpecificOrigins = "_myAllowSpecificOrigins"; // đầu tiền
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
             .AddJwtBearer(options =>
             {
             options.TokenValidationParameters = new TokenValidationParameters
           {
               ValidateIssuer = true,
               ValidateAudience = true,
               ValidateLifetime = true,
               ValidateIssuerSigningKey = true,

               ValidIssuer = builder.Configuration["JWT:Issuer"],
               ValidAudience = builder.Configuration["JWT:Audience"],
               IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"])),
               ClockSkew = TimeSpan.Zero // Đặt thời gian lệch (skew) giữa máy chủ và máy khách (tuỳ chọn)
              };
           });
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen();
            // Kích hoạt Swagger để tài liệu API
            builder.Services.AddEndpointsApiExplorer();
            // Đăng ký dịch vụ giỏ hàng

           builder.Services.AddScoped<IUserServices,UserReporitory>();
            builder.Services.AddAuthorization();         
            builder.Services.AddApplication(); //use automapper
            builder.Services.AddEventBus(builder.Configuration); //use automapper
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  policy =>
                                  {
                                      policy.AllowAnyOrigin();
                                  });
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors(MyAllowSpecificOrigins);
            app.UseAuthorization();
           

            app.MapControllers();

            app.Run();
        }
    }
}
