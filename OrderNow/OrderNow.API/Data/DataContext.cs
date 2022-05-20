using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


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
        public DbSet<CustomersBusinesses> CustomersBusinesses { get; set; }
        public DbSet<Cities> Cities { get; set; }
        public DbSet<Documents> Documents { get; set; }
        public DbSet<FavoriteBusiness> FavoriteBusinessesByCustomer { get; set; }
        public DbSet<FavoriteProducts> FavoriteProductsByCustomer { get; set; }
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


    }

}
