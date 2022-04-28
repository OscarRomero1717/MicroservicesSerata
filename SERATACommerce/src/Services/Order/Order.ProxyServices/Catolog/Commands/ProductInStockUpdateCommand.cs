using System;
using System.Collections.Generic;
using System.Text;

namespace Order.ProxyServices.Catolog.Commands
{

    public enum ProdctInStockAction
    {
        add,
        subtrac
    }
    public class ProductInStockUpdateCommand  
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
