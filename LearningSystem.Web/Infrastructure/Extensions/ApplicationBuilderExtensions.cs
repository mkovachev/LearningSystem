﻿using LearningSystem.Data;
using LearningSystem.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace LearningSystem.Web.Infrastructure.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseDatabaseMigration(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetService<LearningSystemDbContext>().Database.Migrate();

                var userManager = serviceScope.ServiceProvider.GetService<UserManager<User>>();
                var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();


                // create roles
                Task.Run(async () =>
                {
                    var roles = new[]
                    {
                        WebConstants.AdminRole,
                        WebConstants.BlogAuthorRole,
                        WebConstants.TrainerRole
                    };

                    foreach (var role in roles)
                    {
                        var roleExists = await roleManager.RoleExistsAsync(role);

                        if (!roleExists)
                        {
                            var result = await roleManager.CreateAsync(new IdentityRole
                            {
                                Name = role
                            });

                            // result.Errors.ToString();
                        }
                    }

                    // create admin
                    var admin = await userManager.FindByNameAsync("admin@test.com");

                    if (admin == null)
                    {
                        admin = new User
                        {
                            UserName = "admin@test.com",
                            Email = "admin@test.com"
                        };

                        await userManager.CreateAsync(admin, "11223344");

                        await userManager.AddToRoleAsync(admin, WebConstants.AdminRole);
                    }
                })
                .Wait();
            }

            return app;
        }
    }
}
