using Catalog.ServiceEventHandlers;
using Catalog.ServiceEventHandlers.Commands;
using Catalog.ServiceEventHandlers.exeptions;
using CatologDomain;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Catalog.Testing
{
    [TestClass]
    public class ProdcutInStockCreateEventHandlerTest
    {

        private ILogger<ProdcutInStockCreateEventHandler> Getlogger
        {
            get { return new Mock<ILogger<ProdcutInStockCreateEventHandler>>().Object; }
        }


        [TestMethod]
        public void TryToSubstracStockWhenProctHasStock()
        {
            var contex = AplicationBdcontextInMemory.Get();

            var productInStockId = 1;
            var productId = 1;

            contex.Stocks.Add(new ProductInStock
            {
                ProductId = productId,
                ProductInStockId = productInStockId,
                Stock = 1

            });

            contex.SaveChanges();

            var handler = new ProdcutInStockCreateEventHandler(contex, Getlogger);

            handler.Handle(new ProductInStockUpdateCommand
            {
                Items = new List<ProductInStockUpdateItem>()
                {
                    new ProductInStockUpdateItem
                    {
                        ProductId=1,
                        Stock=1,
                        Action=Common.Catalog.Enum.ProdctInStockAction.subtrac
                    }
                }
            }, new System.Threading.CancellationToken()).Wait();

        }



        [TestMethod]
        [ExpectedException(typeof(AggregateException))]
        public void TryToSubstracStockWhenProctHasnotStock()
        {
            var contex = AplicationBdcontextInMemory.Get();

            var productInStockId = 2;
            var productId = 2;

            contex.Stocks.Add(new ProductInStock
            {
                ProductId = productId,
                ProductInStockId = productInStockId,
                Stock = 1

            });

            contex.SaveChanges();

            var handler = new ProdcutInStockCreateEventHandler(contex, Getlogger);

            

            try
            {
                handler.Handle(new ProductInStockUpdateCommand
                {
                    Items = new List<ProductInStockUpdateItem>()
                {
                    new ProductInStockUpdateItem
                    {
                        ProductId=1,
                        Stock=2,
                        Action=Common.Catalog.Enum.ProdctInStockAction.subtrac
                    }
                }
                }, new System.Threading.CancellationToken()).Wait();

            }
            catch (AggregateException ae)
            {
                throw;
            }

        }


        [TestMethod]
        public void TryAddStockWhenProcudtExist()
        {
            var contex = AplicationBdcontextInMemory.Get();

            var productInStockId = 3;
            var productId = 3;

            contex.Stocks.Add(new ProductInStock
            {
                ProductId = productId,
                ProductInStockId = productInStockId,
                Stock = 1

            });

            contex.SaveChanges();

            var handler = new ProdcutInStockCreateEventHandler(contex, Getlogger);

            handler.Handle(new ProductInStockUpdateCommand
            {
                Items = new List<ProductInStockUpdateItem>()
                {
                    new ProductInStockUpdateItem
                    {
                        ProductId=3,
                        Stock=3,
                        Action=Common.Catalog.Enum.ProdctInStockAction.add
                    }
                }
            }, new System.Threading.CancellationToken()).Wait();

           var stockDb = contex.Stocks.Single(x => x.ProductId == productId).Stock;

            Assert.AreEqual(stockDb, 4);


        }
    }
}
