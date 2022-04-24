using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Order.ServiceEventeHandlers.Commands
{
    public  class OrderDetaiCreateCommand : INotification 
    {
       
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        
    }
}
