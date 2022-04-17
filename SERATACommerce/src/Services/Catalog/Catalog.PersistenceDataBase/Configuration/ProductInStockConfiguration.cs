using CatologDomain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.PersistenceDataBase.Configuration
{
    public class ProductInStockConfiguration
    {
        public ProductInStockConfiguration(EntityTypeBuilder<ProductInStock> entityBuilder)
        {
            entityBuilder.HasKey(x => x.ProductInStockId);

            var productsInitial = new List<ProductInStock>();
            var random = new Random();

            for (int i = 1; i < 100; i++)
            {
                productsInitial.Add(new ProductInStock
                {
                    ProductId=i,
                    ProductInStockId=i,Stock= random.Next(0,100)


                });
            }

            entityBuilder.HasData(productsInitial);

        }

    }
}
