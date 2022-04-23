using Catalog.PersistenceDataBase;
using Catalog.ServiceEventHandlers.Commands;
using Catalog.ServiceEventHandlers.exeptions;
using CatologDomain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Catalog.ServiceEventHandlers
{
    public class ProdcutInStockCreateEventHandler:INotificationHandler<ProductInStockUpdateCommand>
    {

        private readonly AplicationDBContext _context;
        private readonly ILogger<ProdcutInStockCreateEventHandler> _logger;


        public ProdcutInStockCreateEventHandler(AplicationDBContext context, ILogger<ProdcutInStockCreateEventHandler> logger) 
        {
            _context = context;
            _logger = logger;
        }


        public async Task Handle(ProductInStockUpdateCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation("--- started  ProductInStockUpdateCommand");
            var idUpdate = command.Items.Select(x => x.ProductId);
            var stocks= await _context.Stocks.Where(x =>  idUpdate.Contains(x.ProductId)).ToListAsync();


            foreach (var item in command.Items)
            {
                var entry = stocks.SingleOrDefault(x => x.ProductId == item.ProductId);

                if (item.Action == Common.Catalog.Enum.ProdctInStockAction.subtrac)
                {
                    if (entry == null || item.Stock > entry.Stock)
                    {
                        _logger.LogError("--- Error ProductInStockUpdateCommand  does not have enought stock  ");
                        throw new ProdcutInStockCreateEventHandlerExption($"Products {entry.ProductId} - doesn´t have enough stock");
                    }

                    entry.Stock = item.Stock;
                    _logger.LogInformation("--- Stock subtrac  ProductInStockUpdateCommand");

                }
                else
                {
                    if (entry == null)
                    {
                        entry = new ProductInStock
                        {
                            ProductId = item.ProductId
                        };

                        await _context.AddAsync(entry);
                        entry.Stock += item.Stock;
                    }

                    entry.Stock += item.Stock;

                }

            }
            await _context.SaveChangesAsync();

            _logger.LogInformation("--- Enden  ProductInStockUpdateCommand");
        }




    }
}
