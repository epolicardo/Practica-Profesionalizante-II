using OrderNow.Blazor.Data;

namespace OrderNow
{
    public abstract class SeedData
    {
        internal static async Task SeedInitialData(WebApplication app)
        {
            var scopeFactory = app!.Services.GetRequiredService<IServiceScopeFactory>();
            using var scope = scopeFactory.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<DataContext>();
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

            context.Database.EnsureCreated();

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
                    Phone = "3513432192"
                };
                businesses.Address = new Addresses()
                {
                    Street = "Ruta E-53",
                    Number = "Km 22.5",
                    City = "Río Ceballos"
                };
                Businesses businesses1 = new Businesses
                {
                    Name = "Pizzeria Popular Unquillo",
                    ValidationExpires = DateTime.UtcNow,
                    ValidationTime = DateTime.UtcNow,
                    ContractURL = "pizzeria-popular-un",
                    CUIT = "129873218361",
                    LegalName = "Pizzerias Populares S.R.L. ",
                    Phone = "3513234292"
                };
                businesses1.Address = new Addresses()
                {
                    Street = "Ruta E-57",
                    Number = "Km 12.5",
                    City = "Unquillo"
                };
                context.Addresses.Add(businesses.Address);
                context.Addresses.Add(businesses1.Address);

                context.Businesses.Add(businesses);
                context.Businesses.Add(businesses1);

                Categories categories = new Categories()
                {
                    Name = "Generics"
                };
                Categories categories1 = new Categories()
                {
                    Name = "Ingredients"
                };

                context.Categories.Add(categories);
                context.Categories.Add(categories1);

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
                        IsSuggested = true
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

                    Products muza = new Products()
                    {
                        Name = "Queso Muzarella",
                        IsSelleable = false,
                        Business = businesses,
                    };
                    context.Products.Add(products);
                    context.Products.Add(products1);
                    context.Products.Add(products2);
                    context.Products.Add(products3);
                    context.Products.Add(products4);
                    context.Products.Add(muza);

                    Ingredients ingredients = new Ingredients()
                    {
                        Ingredient = muza,
                        Quantity = 1,
                    };
                    Recipes recipes = new Recipes()
                    {
                        Name = "Pizza Muzarella",
                        Ingredients = new List<Ingredients> {
                            ingredients,
                            ingredients,
                            ingredients
                        }
                    };
                }

                await context.SaveChangesAsync();
            }
        }
    }
}