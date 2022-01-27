﻿using DIMS_Core.Identity.Configs;
using DIMS_Core.Identity.Entities;
using DIMS_Core.Identity.Interfaces;
using DIMS_Core.Identity.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DIMS_Core.Identity.Extensions
{
    public static class MiddlewareServiceExtensions
    {
        public static IServiceCollection AddIdentityContext(this IServiceCollection services)
        {
            services.AddDbContext<IdentityContext>(options =>
                                                   {
                                                       var config = new IdentityConfiguration();
                                                       options.UseSqlServer(config.ConnectionString);
                                                   });

            services.AddIdentity<User, Role>(configs =>
                                             {
                                                 configs.User.RequireUniqueEmail = true;
                                                 configs.Password = new PasswordOptions
                                                                    {
                                                                        RequireDigit = false,
                                                                        RequireLowercase = false,
                                                                        RequireNonAlphanumeric = false,
                                                                        RequireUppercase = false,
                                                                        RequiredLength = 5
                                                                    };
                                             })
                    .AddEntityFrameworkStores<IdentityContext>()
                    .AddDefaultTokenProviders();

            return services;
        }

        public static IServiceCollection AddIdentityDependencies(this IServiceCollection services)
        {
            services.AddScoped<IIdentityUnitOfWork, IdentityUnitOfWork>();

            return services;
        }
    }
}