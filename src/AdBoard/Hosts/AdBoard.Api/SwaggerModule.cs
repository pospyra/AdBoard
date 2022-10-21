using AdBoard.AppServices.Ad.Repositories;
using AdBoard.AppServices.Ad.Services;
using AdBoard.AppServices;
using AdBoard.AppServices.SelectedAd.Services;
using AdBoard.AppServices.Services;
using AdBoard.AppServices.User.IRepository;
using AdBoard.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using SelectedAd.DataAccess.EntityConfiguration.Ad;
using SelectedAd.DataAccess.EntityConfiguration.SelectedAd;
using SelectedAd.DataAccess.EntityConfiguration.User;
using SelectedAd.DataAccess.Interface;
using SelectedAd.DataAccess;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using SelectedAd.Contracts;

namespace AdBoard.Api
{
    /// <summary>
    /// Подключение Swagger
    /// </summary>
    public static class SwaggerModule
    {
        public static IServiceCollection AddSwaggerModule(this IServiceCollection services) {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(name: "v1", new OpenApiInfo { Title = "AdBoard.Api", Version = "v1" });
                options.IncludeXmlComments(Path.Combine(Path.Combine(AppContext.BaseDirectory,
                     $"{typeof(SelectedAdDto).Assembly.GetName().Name}.xml")));
                options.IncludeXmlComments(Path.Combine(Path.Combine(AppContext.BaseDirectory, "Documentation.xml")));
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Autorization header using the Bearer scheme",
                    Name = "Autorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = JwtBearerDefaults.AuthenticationScheme
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement {
    {
        new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            },
            Scheme = "oauth2",
            Name = "Bearer",
            In = ParameterLocation.Header,
        },
        new List<string>()
        }
    });
            });
            return services;
        }
    }
}
