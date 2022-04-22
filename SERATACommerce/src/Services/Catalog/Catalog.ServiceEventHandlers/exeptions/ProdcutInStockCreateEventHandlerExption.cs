using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.ServiceEventHandlers.exeptions
{
    public  class ProdcutInStockCreateEventHandlerExption : Exception
    {
        public  ProdcutInStockCreateEventHandlerExption ( string menssage) :base(menssage)
        {
        } 
    }
}
