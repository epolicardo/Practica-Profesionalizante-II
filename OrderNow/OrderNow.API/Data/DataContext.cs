using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using OrderNow.API.Data.Entities;

namespace OrderNow.Data
{
    public class DataContext : IdentityDbContext<IdentityUser>
    {
        
        public DataContext()
        {
            
        }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
      
        }

        public DbSet<Addresses> Addresses { get; set; }
        public DbSet<Businesses> Businesses { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<UsersBusinesses> UsersBusinesses { get; set; }
        public DbSet<Cities> Cities { get; set; }
        public DbSet<Documents> Documents { get; set; }
        public DbSet<FavoriteBusiness> FavoriteBusinessesByUser { get; set; }
        public DbSet<FavoriteProducts> FavoriteProductsByUser { get; set; }
        public DbSet<Groups> Grupos { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrdersDetail> OrdersDetail { get; set; }
        public DbSet<PaymentMethods> PaymentMethods { get; set; }
        public DbSet<People> People { get; set; }
        public DbSet<ProductOptions> ProductOptions { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<PublicityContract> PublicityContracts { get; set; }
        public DbSet<OrderQueue> Queues { get; set; }
        public DbSet<Sales> Sales { get; set; }
        public DbSet<SaleDetails> SaleDetails { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UsersOrders> UsersOrders { get; set; }
    }

}
