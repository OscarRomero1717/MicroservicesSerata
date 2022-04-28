using MediatR;
using Order.Domain;
using Order.PersistenceDataBase;
using Order.ServiceEventeHandlers.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
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


        public async Task Handle(OrderCreateCommand notification, CancellationToken cancellationToken)
        {


            try
            {
                var entry = new OrderClient();

                using (var txt = await _aplicationDBContext.Database.BeginTransactionAsync())
                {

                    PrepareDatail(entry, notification);

                    PrepareHeader(entry, notification);

                    await _aplicationDBContext.AddAsync(entry);
                    await _aplicationDBContext.SaveChangesAsync();
                    await txt.CommitAsync();
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        private void PrepareDatail(OrderClient order, OrderCreateCommand commandApi)
        {
            order.Items = commandApi.Items.Select(x => new OrderDetail
            {
                ProductId = x.ProductId,
                Quantity = x.Quantity,
                UnitPrice = x.UnitPrice,
                Total = x.UnitPrice * x.Quantity

            }).ToList();

        }

        private void PrepareHeader(OrderClient order, OrderCreateCommand commandApi)
        {
            order.CreatedDate = DateTime.UtcNow;
            order.Status = Common.Enums.OrderStatus.pending;
            order.Payment = commandApi.Payment;
            order.ClientId = commandApi.ClientId; ;
            order.Total= order.Items.Sum(x => x.Total);
            

        }
    }
}
