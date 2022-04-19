using Catalog.PersistenceDataBase;
using Catalog.ServiceEventHandlers.Commands;
using MediatR;
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
            var stocks= _context.Stocks.Where(x =>  idUpdate.Contains(x.ProductId)).ToList();


            foreach (var item in stocks)
            {

            }
            await _context.SaveChangesAsync();

            _logger.LogInformation("--- Enden  ProductInStockUpdateCommand");
        }




    }
}
