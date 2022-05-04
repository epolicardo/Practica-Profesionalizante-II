using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using OrderNow.Data.Entities;

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
        public DbSet<Cities> Cities { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<PaymentMethods> PaymentMethods { get; set; }
        public DbSet<People> People { get; set; }
        public DbSet<ProductOptions> ProductOptions { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Sales> Sales { get; set; }
        public DbSet<SaleDetails> SaleDetails { get; set; }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{

        //    //modelBuilder
        //    //    .Entity<Businesses>()
        //    //    .HasMany(e => e.CustomersList)
        //    //    .WithMany(e => e.FavoriteBusinesses)
        //    //    .UsingEntity<Dictionary<string, object>>(
        //    //        "FavoriteBussinesCustomer",
        //    //        b => b.HasOne<Customers>().WithMany().HasForeignKey("Id"),
        //    //        b => b.HasOne<Businesses>().WithMany().HasForeignKey("Id"));

        //    //modelBuilder
        //    //   .Entity<Businesses>()
        //    //   .HasMany(e => e.CustomersList)
        //    //   .WithMany(e => e.FavoriteBusinesses)
        //    //   .UsingEntity<Dictionary<string, object>>(
        //    //       "BussinesVIPCustomer",
        //    //       b => b.HasOne<Customers>().WithMany().HasForeignKey("Id"),
        //    //       b => b.HasOne<Businesses>().WithMany().HasForeignKey("Id"));
            
        //    //modelBuilder
        //    //   .Entity<Customers>()
        //    //   .HasMany(e => e.FavoriteBusinesses)
        //    //   .WithMany(e => e.CustomersList)
        //    //   .UsingEntity<Dictionary<string, object>>(
        //    //       "FavoriteBussinesCustomer",
        //    //       b => b.HasOne<Businesses>().WithMany().HasForeignKey("Id"),
        //    //       b => b.HasOne<Customers>().WithMany().HasForeignKey("Id"));
        //}
    }

}
