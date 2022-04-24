using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using static Order.Common.Enums;

namespace Order.ServiceEventeHandlers.Commands
{
    public  class OrderCreateCommand  :INotification 
    {

        public int ClientId { get; set; }
      

        public OrderPayment Payment { get; set; }

        public IEnumerable<OrderDetaiCreateCommand> Items { get; set; }
    }
}
