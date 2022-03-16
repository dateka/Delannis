using Microsoft.EntityFrameworkCore;
using Ynov.Delannis.Domain.productAggregate;
using Ynov.Delannis.Domain.UserAggregate;

namespace Ynov.Delannis.Infrastructure.Adapters.Database
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) 
            : base(options) { }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>(user =>
            {
                user.HasKey(_ => _.Id);
                user.Property(_ => _.UserName).IsRequired();
                user.Property(_ => _.Password).IsRequired();
                user.Property(_ => _.Email).IsRequired();
            });

            modelBuilder.Entity<Product>(product =>
            {
                product.HasKey(_ => _.Id);
                product.Property(_ => _.Label).IsRequired();
                product.Property(_ => _.TaxedPrice).IsRequired();
                product.Property(_ => _.TaxRate).IsRequired();
                product.Property(_ => _.StockQuantity).IsRequired();
            });
        }
    }
}