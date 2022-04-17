using Catalog.PersistenceDataBase.Configuration;
using CatologDomain;
using Microsoft.EntityFrameworkCore;


namespace Catalog.PersistenceDataBase
{
    public class AplicationDBContext : DbContext
    {
        public AplicationDBContext(DbContextOptions<AplicationDBContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductInStock> Stocks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema("Catalog");
            ModelConfig(builder);
        }

        private void ModelConfig(ModelBuilder modelBuilder)
        {
            new ProductConfiguration(modelBuilder.Entity<Product>());
            new ProductInStockConfiguration(modelBuilder.Entity<ProductInStock>());
        }
    }
}
