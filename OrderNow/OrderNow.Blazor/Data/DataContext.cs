using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace OrderNow.Blazor.Data
{
    public class DataContext : IdentityDbContext<Users>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Business> Businesses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<UserBusiness> UsersBusinesses { get; set; }
        public DbSet<Document> Documents { get; set; }

        public DbSet<FavoriteProducts> FavoriteProductsByUser { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<Recipes> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<ProductOptions> ProductOptions { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<AdvertisingContract> AdvertisingContracts { get; set; }
        public DbSet<OrderQueue> Queues { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<UserOrder> UsersOrders { get; set; }
    }
}