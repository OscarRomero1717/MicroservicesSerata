using CatologDomain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace Catalog.PersistenceDataBase.Configuration
{
    public class ProductConfiguration
    {
        public ProductConfiguration(EntityTypeBuilder<Product> entityBuilder)
        {
            entityBuilder.HasIndex(x => x.ProductId);
            entityBuilder.Property(x => x.NameProduct).IsRequired().HasMaxLength(100);
            entityBuilder.Property(x => x.DescriptionProduct).IsRequired().HasMaxLength(500);

            var productsInitial = new List<Product>();
            var random = new Random();

            for (int i = 0; i < 100; i++)
            {
                productsInitial.Add(new Product
                {
                    ProductId = i,
                    NameProduct = $"Product{i}",
                    DescriptionProduct = $"Description {i}",
                    Price = random.Next(1, 500)
                });
            }

            entityBuilder.HasData(productsInitial);
        }
    }
}
