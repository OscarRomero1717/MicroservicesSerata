using Microsoft.EntityFrameworkCore;
using Order.Domain;
using Order.PersistenceDataBase.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Order.PersistenceDataBase
{
    public class AplicationDBContext : DbContext
    {
        public AplicationDBContext(DbContextOptions<AplicationDBContext> options) : base(options)
        { 
        
        }

        public DbSet<OrderDetail> Detail { get; set; }

        public DbSet<OrderClient> Orders { get; set; }

        protected override void OnModelCreating (ModelBuilder builder) 
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema("Order");
            ModelConfig(builder);

        }

        private void ModelConfig(ModelBuilder modelBuilder)
        {
            new OrderDetailConfiguration(modelBuilder.Entity<OrderDetail>());
            new OrderClientConfiguration(modelBuilder.Entity<OrderClient>());

        }
    }
}
