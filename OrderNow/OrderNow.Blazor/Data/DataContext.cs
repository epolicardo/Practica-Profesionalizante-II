using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace OrderNow.Blazor.Data
{
    public class DataContext : IdentityDbContext<Users>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        public DbSet<Addresses> Addresses { get; set; }
        public DbSet<Businesses> Businesses { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<UsersBusinesses> UsersBusinesses { get; set; }
        public DbSet<Documents> Documents { get; set; }

        public DbSet<FavoriteProducts> FavoriteProductsByUser { get; set; }
        public DbSet<Groups> Groups { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<Recipes> Recipes { get; set; }
        public DbSet<Ingredients> Ingredients { get; set; }
        public DbSet<PaymentMethods> PaymentMethods { get; set; }
        public DbSet<People> People { get; set; }
        public DbSet<ProductOptions> ProductOptions { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<AdvertisingContracts> AdvertisingContracts { get; set; }
        public DbSet<OrderQueue> Queues { get; set; }
        public DbSet<Sales> Sales { get; set; }
        public DbSet<SaleDetails> SaleDetails { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<UsersOrders> UsersOrders { get; set; }
    }
}