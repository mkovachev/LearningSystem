using LearningSystem.Data;
using LearningSystem.Data.Models;
using LearningSystem.Web.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace CameraShop.Web.Infrastructure.Extensions
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


                // add admin user and amdin role
                Task.Run(async () =>
                {
                    var adminRole = GlobalConstants.AdminRole;
                    var adminRoleExists = await roleManager.RoleExistsAsync(adminRole);

                    if (!adminRoleExists)
                    {
                        var result = await roleManager.CreateAsync(new IdentityRole
                        {
                            Name = adminRole
                        });

                        //result.Errors...
                    }

                    var admin = await userManager.FindByNameAsync("admin@test.com");

                    if (admin == null)
                    {
                        admin = new User
                        {
                            UserName = "admin@test.com",
                            Email = "admin@test.com"
                        };

                        await userManager.CreateAsync(admin, "123456");

                        await userManager.AddToRoleAsync(admin, GlobalConstants.AdminRole);
                    }
                })
                .Wait();
            }

            return app;
        }
    }
}
