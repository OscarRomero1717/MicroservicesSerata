using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Order.PersistenceDataBase.Configuration
{
    public class OrderClientConfiguration
    {
        public OrderClientConfiguration(EntityTypeBuilder<OrderClient> entity) 
        {

            entity.HasKey(x=> x.OrderId);
            entity.Property(X => X.Payment).IsRequired();
            entity.Property(X => X.Status).IsRequired();
            entity.Property(X => X.ClientId).IsRequired();
            entity.Property(X => X.Total).IsRequired();
            entity.Property(X => X.CreatedDate).IsRequired();


        }
    }
}
