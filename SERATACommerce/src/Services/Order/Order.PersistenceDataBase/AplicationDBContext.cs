using Microsoft.EntityFrameworkCore;
using Order.Domain;
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

       public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> Detail { get; set; }
    }
}
