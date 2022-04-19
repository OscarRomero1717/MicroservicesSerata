using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using static Common.Catalog.Enum;

namespace Catalog.ServiceEventHandlers.Commands
{
    public class ProductInStockUpdateCommand : INotification
    {
        public IEnumerable<ProductInStockUpdateItem> Items { get; set; }
    }

    public class ProductInStockUpdateItem 
    {
        public int ProductId { get; set; }

        public int Stock { get; set; }

        public ProdctInStockAction Action { get; set; }


    }
}
