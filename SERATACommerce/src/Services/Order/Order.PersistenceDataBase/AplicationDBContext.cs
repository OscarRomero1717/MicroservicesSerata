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

        public DbSet<OrderDetail> OrderDetail { get; set; }

        public DbSet<OrderClient> OrderClient { get; set; }

        protected override void OnModelCreating (ModelBuilder builder) 
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema("orders");
            ModelConfig(builder);

        }

        private void ModelConfig(ModelBuilder modelBuilder)
        {
            new OrderDetailConfiguration(modelBuilder.Entity<OrderDetail>());
            new OrderClientConfiguration(modelBuilder.Entity<OrderClient>());

        }
    }
}
