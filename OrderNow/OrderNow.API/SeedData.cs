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



            if (!context.Cities.Any())
            {
                Cities cities = new Cities()
                {
                    Name = "Córdoba"
                };
                context.Cities.Add(cities);
            }


            if (!context.Businesses.Any())
            {
                Businesses businesses = new Businesses
                {
                    Name = "Pizzeria Popular Rio Ceballos",
                    ValidationExpires = DateTime.UtcNow,
                    ValidationTime = DateTime.UtcNow,
                    ContractURL = "pizzeria-popular-rc",
                    CUIT = "303078219599",
                    LegalName = "Pizzerias Populares S.R.L. ",
                    Phone = "3513416192"

                };
                businesses.Address = new Addresses()
                {
                    Street = "Ruta E-53",
                    Number = "Km 22.5",
                    City = context.Cities.FirstOrDefault(x => x.Name.Equals("Córdoba"))
                };

                context.Businesses.Add(businesses);

                if (!context.Products.Any())
                {
                    Products products = new Products
                    {
                        Name = "Coca Cola Lata 354cc",
                        EAN = "1236789786989765432",
                        Business = businesses
                    };

                    Products products1 = new Products
                    {
                        Name = "Sprite Lata 354cc",
                        EAN = "12368979653424",
                        Business = businesses
                    };
                    Products products2 = new Products
                    {
                        Name = "Fanta Lata 354cc",
                        EAN = "567897689678936346",
                        Business = businesses, 
                        IsSuggested=true
                    };
                    Products products3 = new Products
                    {
                        Name = "Stella 354 cc",
                        EAN = "1798986789432",
                        Business = businesses
                    };

                    Products products4 = new Products
                    {
                        Name = "Quilmes Lata 354cc",
                        EAN = "12234523455432",
                        Business = businesses
                    };

                    context.Products.Add(products);
                    context.Products.Add(products1);
                    context.Products.Add(products2);
                    context.Products.Add(products3);
                    context.Products.Add(products4);
                   
                }
            }


            if (!userManager.Users.Any())
            {
                User user = new User
                {
                    Email = "emilianopolicardo@gmail.com",
                    UserName = "epolicardo",
                    Password = "Em1Li4N*",
                    person = new People
                    {
                        BirthDate = new DateTime(1984, 12, 17),
                        FirstName = "Emiliano",
                        LastName = "Policardo"
                    }
                };
                user.PasswordHash = userManager.PasswordHasher.HashPassword(user, user.Password);
                await userManager.CreateAsync(user, user.Password);
                await roleManager.CreateAsync(new IdentityRole
                {
                    Name = "Admin"
                });
                await roleManager.CreateAsync(new IdentityRole
                {
                    Name = "Owner"
                });

                await userManager.AddToRoleAsync(user, "Admin");
                await userManager.AddToRoleAsync(user, "Owner");
            }




            await context.SaveChangesAsync();
        }


    }
}
