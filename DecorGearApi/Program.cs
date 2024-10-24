using DecorGearApplication.Interface;
using DecorGearApplication.IServices;
using DecorGearApplication.Services;
using DecorGearDomain.Data.Entities;
using DecorGearInfrastructure.Database.AppDbContext;
using DecorGearInfrastructure.Extention;
using DecorGearInfrastructure.Extention.AutoMapperProfile;
using DecorGearInfrastructure.implement;
using DecorGearInfrastructure.Implement;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Configure DbContext
        ConfigureDbContext(builder);

        // Add services to the container
        ConfigureServices(builder);

        // Configure CORS
        ConfigureCors(builder);

        // Configure Authentication and JWT
        ConfigureAuthentication(builder);

        var app = builder.Build();

        // Configure the HTTP request pipeline
        ConfigureMiddleware(app);

        app.Run();
    }

    private static void ConfigureDbContext(WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
    }

    private static void ConfigureServices(WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // Register services
        builder.Services.AddScoped<ITokenServices, TokenServices>();
        builder.Services.AddScoped<IUserRespository, UserRepository>();
        builder.Services.AddScoped<IUserServices, UserServices>();
        builder.Services.AddScoped<IPasswordServices, PasswordServices>();
        builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));
        builder.Services.AddScoped<IMailingServices, MailingServices>();
        builder.Services.AddScoped<IFeedBackRespository, FeedBackRepository>();
        builder.Services.AddScoped<IFeedbackServices, FeedbackServices>();
        builder.Services.AddScoped<IMemberRespository, MemberRepository>();
        builder.Services.AddScoped<IMemberServices, MemberServices>();
        builder.Services.AddEventBus(builder.Configuration);
        builder.Services.AddAutoMapper(typeof(UserProfile), typeof(FeedBackProfile));

        builder.Services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = "localhost:6379"; // Cấu hình Redis
        });
    }



    private static void ConfigureCors(WebApplicationBuilder builder)
    {
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", builder =>
            {
                builder.AllowAnyOrigin() // Cho phép tất cả các nguồn
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            });
        });
    }

    private static void ConfigureAuthentication(WebApplicationBuilder builder)
    {
        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            var secretKey = builder.Configuration["JWT:Secret"];
            var issuer = builder.Configuration["JWT:Issuer"];
            var audience = builder.Configuration["JWT:Audience"];

            if (string.IsNullOrEmpty(secretKey))
            {
                throw new ArgumentNullException("JWT:Secret", "The JWT secret key cannot be null or empty.");
            }

            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = issuer,
                ValidAudience = audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
            };
        });

        builder.Services.AddHttpContextAccessor();
    }

    private static void ConfigureMiddleware(WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseCors("AllowAll");
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();
    }
}
