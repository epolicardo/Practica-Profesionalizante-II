

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using OrderNow.API.Data;

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
        public DbSet<Business> Business { get; set; }
        public DbSet<Cities> Cities { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<PaymentMethods> PaymentMethods { get; set; }
        public DbSet<People> People { get; set; }
        public DbSet<ProductOptions> ProductOptions { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Sales> Sales { get; set; }
        public DbSet<SaleDetails> SaleDetails { get; set; }
     
    }
}
