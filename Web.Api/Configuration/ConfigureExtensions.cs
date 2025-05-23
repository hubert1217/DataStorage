﻿using Web.Application.Abstractions.DataAccess;
using Web.Application.Abstractions.Services;
using Web.Application.Services;
using Web.Application.Validation;
using Web.Infrastructure.Configuration;
using Web.Infrastructure.Database;
using FluentValidation;

namespace Web.Api.Configuration
{
    public static class ConfigureExtensions
    {
        public static WebApplicationBuilder ConfigureApplication(this WebApplicationBuilder builder) 
        {
            builder
                .Services
                .AddServices()
                .AddInfrastructure(builder.Configuration)
                .AddCors()
                .AddSwagger()
                .AddControllers();

            return builder;
        }

        private static IServiceCollection AddSwagger(this IServiceCollection services) 
        { 
            services
                .AddSwaggerGen()
                .AddEndpointsApiExplorer();

            return services;
        }

        private static IServiceCollection AddCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowFrontend",
                    policy =>
                    {
                        policy.WithOrigins("http://localhost:59311")
                              .AllowAnyMethod()
                              .AllowAnyHeader();
                    });
            });
            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IReadingService, ReadingService>();
            services.AddScoped<IMeterService, MeterService>();

            services.AddScoped<IUserDao, UserDao>();
            services.AddScoped<IReadingDao, ReadingDao>();
            services.AddScoped<IMeterDao, MeterDao>();

            services.AddValidatorsFromAssemblyContaining<UserValidator>();

            return services;
        }

        
    }
}
