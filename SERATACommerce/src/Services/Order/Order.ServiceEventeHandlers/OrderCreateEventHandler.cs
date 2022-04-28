using MediatR;
using Order.Domain;
using Order.PersistenceDataBase;
using Order.ProxyServices.Catolog;
using Order.ProxyServices.Catolog.Commands;
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

        private readonly ICatalogProxy _catalogProxy;
        public OrderCreateEventHandler(AplicationDBContext aplicationDBContext, ICatalogProxy catalogProxy)
        {
            _aplicationDBContext = aplicationDBContext;
            _catalogProxy = catalogProxy;
        }


        public async Task Handle(OrderCreateCommand notification, CancellationToken cancellationToken)
        {

            var entry = new OrderClient();

            using (var txt = await _aplicationDBContext.Database.BeginTransactionAsync())
            {

                PrepareDatail(entry, notification);

                PrepareHeader(entry, notification);

                await _aplicationDBContext.AddAsync(entry);
                await _aplicationDBContext.SaveChangesAsync();

                await _catalogProxy.UpdateStockAsync( new ProductInStockUpdateCommand()
                {
                    Items = notification.Items.Select(x=> new ProductInStockUpdateItem
                    {
                        ProductId = x.ProductId,
                        Stock= x.Quantity,
                        Action = ProdctInStockAction.subtrac

                    })
                    

                });


                await txt.CommitAsync();
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
            order.Total = order.Items.Sum(x => x.Total);


        }
    }
}
