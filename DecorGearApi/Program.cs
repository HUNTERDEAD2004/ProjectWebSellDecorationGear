
using DecorGearApplication.Interface;
using DecorGearDomain.Data.Entities;
using DecorGearInfrastructure.Database.AppDbContext;
using DecorGearInfrastructure.Extention;
using DecorGearInfrastructure.Extention.AutoMapperProfile;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Security.Cryptography.Xml;
using System.Text;

public class Program
{
    public static void Main(string[] args)
    {

        const string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddApplication();
        builder.Services.AddEventBus(builder.Configuration);
        //builder.Services.AddAutoMapper(typeof(UserProfile));

        // Configure CORS
        builder.Services.AddCors(options =>
        {
            options.AddPolicy(name: "_myAllowSpecificOrigins",
                              policy =>
                              {
                                  policy.AllowAnyOrigin()
                                        .AllowAnyHeader()
                                        .AllowAnyMethod();
                              });
        });

        // Authenticator swagger
        // builder.Services.AddSwaggerGen(d =>
        // {
        //    d.AddSecurityDefinition("Bearer",
        //        new OpenApiSecurityScheme
        //        {
        //            Description = "JWT Authorization header using the Bearer scheme ",
        //            Name = "Authorization",
        //            In = ParameterLocation.Header,
        //            Type = SecuritySchemeType.ApiKey,
        //            Scheme = "Bearer"
        //        });

        //    d.AddSecurityRequirement(new OpenApiSecurityRequirement
        //    {
        //        {
        //            new OpenApiSecurityScheme
        //            {
        //                 Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer"}
        //            },
        //            Array.Empty<string>()
        //        }
        //    });
        // });

        // Configure Authentication and JWT Bearer
        // builder.Services.AddAuthentication(options =>
        // {
        //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        // })
        //    .AddJwtBearer(options =>
        //    {
        //        var secretKey = builder.Configuration["JWT:Secret"];
        //        var issuer = builder.Configuration["JWT:Issuer"];
        //        var audience = builder.Configuration["JWT:Audience"];

        //        if (string.IsNullOrEmpty(secretKey))
        //        {
        //            throw new ArgumentNullException("JWT:Secret", "The JWT secret key cannot be null or empty.");
        //        }

        //        options.TokenValidationParameters = new TokenValidationParameters
        //        {
        //            ValidateIssuer = true,
        //            ValidateAudience = true,
        //            ValidateLifetime = true,
        //            ValidateIssuerSigningKey = true,
        //            ValidIssuer = issuer,
        //            ValidAudience = audience,
        //            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
        //        };
        // });

        //builder.Services.AddTransient<UserRepository>();
        //builder.Services.AddTransient<TokenRepository>();
        //builder.Services.AddTransient<HashRepository>();


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseCors("*");
        app.UseAuthentication();
        app.UseAuthorization();
        // app.UseMiddleware<TokenMiddleware>();
        app.MapControllers();

        app.Run();
    }
}

//namespace DecorGearApi
//{
//    public class Program
//    {
//        public static void Main(string[] args)
//        {
//            const string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

//            var builder = WebApplication.CreateBuilder(args);

//            // Add services to the container.

//            builder.Services.AddControllers();
//            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//            builder.Services.AddEndpointsApiExplorer();
//            builder.Services.AddSwaggerGen();
//            builder.Services.AddAutoMapper();
//            builder.Services.AddApplication();
//            builder.Services.AddEventBus(builder.Configuration); //use automapper
//            builder.Services.AddCors(options =>////
//            {
//                options.AddPolicy("AllowLocalhost",
//                    builder =>
//                    {
//                        builder.AllowAnyOrigin()
//                               .AllowAnyMethod()
//                               .AllowAnyHeader();
//                    });
//            });

//            var app = builder.Build();

//            // Configure the HTTP request pipeline.
//            if (app.Environment.IsDevelopment())
//            {
//                app.UseSwagger();
//                app.UseSwaggerUI();
//            }

//            app.UseHttpsRedirection();

//            app.UseAuthorization();


//            app.MapControllers();

//            app.Run();
//        }
//    }
//}
