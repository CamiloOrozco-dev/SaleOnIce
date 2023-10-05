using Microsoft.EntityFrameworkCore;
using SaleOnIce.Models;

namespace SaleOnIce.Repository
{
    public class SaleOnIceContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Purchase> Purchase { get; set; }

        public SaleOnIceContext(DbContextOptions<SaleOnIceContext> options) : base(options)
        {
        }

        //Fluent API

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Product> productsSeed = new List<Product>();
            
            productsSeed.Add(new Product() { Id = 1, Name = "Helmet", Image = "", Description = "Lorem", PreviousPrice = 30.99, Price = 27.99, Quantity = 3, InStock = true });
            productsSeed.Add(new Product() { Id = 2, Name = "Shoes", Image = "", Description = "Lorem", PreviousPrice = 70.99, Price = 60.99, Quantity = 2, InStock = true });

            modelBuilder.Entity<Product>(product =>
            {
                product.HasKey (x => x.Id);
                product.Property(x => x.Name).IsRequired().HasMaxLength(128);
                product.Property(x => x.Image).IsRequired();
                product.Property(x => x.Description).HasMaxLength(35);
                product.Property(x => x.PreviousPrice);
                product.Property(x => x.Price).IsRequired();
                product.Property(x => x.Quantity).IsRequired();
                product.Property(x => x.InStock);
                product.HasData(productsSeed);
            });

            modelBuilder.Entity<User>(user =>
            {
                user.HasKey(x => x.Id);
              
                user.Property(x => x.Name).IsRequired().HasMaxLength(130);
                user.Ignore(x => x.productsUser);
                user.Ignore(x=> x.debitCard);
            });

            modelBuilder.Entity<Purchase>(purchase =>
            {
                purchase.HasKey(x => x.Id);
                purchase.Property(x => x.Date);
            });
        }
    }
}