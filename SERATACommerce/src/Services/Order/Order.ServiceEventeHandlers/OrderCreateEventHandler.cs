using MediatR;
using Order.PersistenceDataBase;
using Order.ServiceEventeHandlers.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Order.ServiceEventeHandlers
{
    public class OrderCreateEventHandler : INotificationHandler<OrderCreateCommand>
    {
        private readonly AplicationDBContext _aplicationDBContext;
        public OrderCreateEventHandler(AplicationDBContext aplicationDBContext)
        {
            _aplicationDBContext = aplicationDBContext;
        }


        public Task Handle(OrderCreateCommand notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
