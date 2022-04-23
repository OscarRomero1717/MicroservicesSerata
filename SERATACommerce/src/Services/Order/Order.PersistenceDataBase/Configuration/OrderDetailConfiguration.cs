using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Order.PersistenceDataBase.Configuration
{
    public class OrderDetailConfiguration
    {
        public OrderDetailConfiguration(EntityTypeBuilder<OrderDetail> entity)
        {

            entity.HasKey(x => x.OrderDetailId);
            entity.Property(x => x.Quantity).IsRequired();
            entity.Property(x => x.Total).IsRequired();
            entity.Property(x => x.UnitPrice).IsRequired();
            entity.Property(x => x.ProductId).IsRequired();


        }
    }
}
