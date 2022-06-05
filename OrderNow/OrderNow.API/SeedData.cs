using Microsoft.AspNetCore.Identity;

namespace OrderNow.API
{
    public abstract class SeedData
    {
        

        internal static async Task SeedInitialData(WebApplication app)
        {

            var scopeFactory = app!.Services.GetRequiredService<IServiceScopeFactory>();
            using var scope = scopeFactory.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<DataContext>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

            context.Database.EnsureCreated();

            if (userManager.Users.Any())
            {
                logger.LogInformation("Creando usuario de prueba");

                var newUser = new User
                {
                    Email = "test@demo.com",
                    UserName = "test.demo"
                };

                await userManager.CreateAsync(newUser, "P@ss.W0rd");
                await roleManager.CreateAsync(new IdentityRole
                {
                    Name = "Admin"
                });
                await roleManager.CreateAsync(new IdentityRole
                {
                    Name = "Owner"
                });

                await userManager.AddToRoleAsync(newUser, "Admin");
                await userManager.AddToRoleAsync(newUser, "Owner");
            }
        }

        
    }
}
