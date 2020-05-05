using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CourseManager
{
    public class Program
    {
        public static void InitializeRoles(RoleManager<IdentityRole> roleManager)
        {
            var adminExists = roleManager.RoleExistsAsync("Admin")
                        .GetAwaiter()
                        .GetResult();

            if (!adminExists)
            {
                roleManager.CreateAsync(new IdentityRole("Admin"))
                            .GetAwaiter()
                            .GetResult();
            }

        }

        public static void InitializeAdminUsers(UserManager<IdentityUser> userManager)
        {
            var adminUser = userManager.FindByEmailAsync("admin@admin.com")
                                        .GetAwaiter()
                                        .GetResult();
            if (adminUser != null)
            {
                var result = userManager.AddToRoleAsync(adminUser, "Admin")
                            .GetAwaiter()
                            .GetResult();
                

            }
        }
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var roleManager = services.GetService<RoleManager<IdentityRole>>();
                var userManager = services.GetService<UserManager<IdentityUser>>();
                InitializeRoles(roleManager);
                InitializeAdminUsers(userManager);
            }


            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
