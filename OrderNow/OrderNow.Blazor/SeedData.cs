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
                Business businesses = new Business
                {
                    Name = "Pizzeria Popular Rio Ceballos",
                    ValidationExpires = DateTime.UtcNow,
                    ValidationTime = DateTime.UtcNow,
                    ContractURL = "pizzeria-popular-rc",
                    CUIT = "303078219599",
                    LegalName = "Pizzerias Populares S.R.L. ",
                    Phone = "3513432192"
                };
                businesses.Address = new Address()
                {
                    Street = "Ruta E-53",
                    Number = "Km 22.5",
                    City = "Río Ceballos"
                };
                Business businesses1 = new Business
                {
                    Name = "Pizzeria Popular Unquillo",
                    ValidationExpires = DateTime.UtcNow,
                    ValidationTime = DateTime.UtcNow,
                    ContractURL = "pizzeria-popular-un",
                    CUIT = "129873218361",
                    LegalName = "Pizzerias Populares S.R.L. ",
                    Phone = "3513234292"
                };
                businesses1.Address = new Address()
                {
                    Street = "Ruta E-57",
                    Number = "Km 12.5",
                    City = "Unquillo"
                };
                context.Addresses.Add(businesses.Address);
                context.Addresses.Add(businesses1.Address);

                context.Businesses.Add(businesses);
                context.Businesses.Add(businesses1);

                Category categories = new Category()
                {
                    Name = "Generics"
                };
                Category categories1 = new Category()
                {
                    Name = "Ingredient"
                };

                context.Categories.Add(categories);
                context.Categories.Add(categories1);

                if (!context.Products.Any())
                {
                    Product products = new Product
                    {
                        Name = "Coca Cola Lata 354cc",
                        EAN = "1236789786989765432",
                        Business = businesses
                    };

                    Product products1 = new Product
                    {
                        Name = "Sprite Lata 354cc",
                        EAN = "12368979653424",
                        Business = businesses
                    };
                    Product products2 = new Product
                    {
                        Name = "Fanta Lata 354cc",
                        EAN = "567897689678936346",
                        Business = businesses,
                        IsSuggested = true
                    };
                    Product products3 = new Product
                    {
                        Name = "Stella 354 cc",
                        EAN = "1798986789432",
                        Business = businesses
                    };

                    Product products4 = new Product
                    {
                        Name = "Quilmes Lata 354cc",
                        EAN = "12234523455432",
                        Business = businesses
                    };

                    Product muza = new Product()
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

                    Ingredient ingredients = new Ingredient()
                    {
                        itemIngredient = muza,
                        Quantity = 1,
                    };
                    Recipes recipes = new Recipes()
                    {
                        Name = "Pizza Muzarella",
                        Ingredients = new List<Ingredient> {
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