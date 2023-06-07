﻿using BidHeroApp.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using BidHeroApp.Services.Contracts;
using BidHeroApp.Services;
using BidHeroApp.Constants;
using FluentValidation;
using System;
using BidHeroApp.InputModels;
using BidHeroApp.Validators;

namespace BidHeroApp.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection InitializeDatabase(this IServiceCollection services)
        {
            var context = services.BuildServiceProvider().GetService<ApplicationDbContext>();

            if (context != null)
            {
                string[] roles = new string[] { Role.Owner , Role.Administrator, Role.User };

                foreach (string role in roles)
                {
                    var roleStore = new RoleStore<IdentityRole>(context);

                    if (!context.Roles.Any(r => r.Name == role))
                    {
                        var newRole = new IdentityRole(role);
                        newRole.NormalizedName = role.ToUpper();
                        roleStore.CreateAsync(newRole).GetAwaiter().GetResult();
                    }
                }
            }

            return services;
        }

        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IItemService, ItemService>();

            return services;
        }

        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddScoped<IValidator<CategoryInputModel>, CategoryInputModelValidator>();
            services.AddScoped<IValidator<ItemInputModel>, ItemInputModelValidator>();
            services.AddScoped<IValidator<ItemsInputModel>, ItemsInputModelValidator>();

            return services;
        }

    }
}
