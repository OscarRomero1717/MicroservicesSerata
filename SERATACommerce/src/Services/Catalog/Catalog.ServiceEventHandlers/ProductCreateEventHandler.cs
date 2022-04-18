using Catalog.PersistenceDataBase;
using Catalog.ServiceEventHandlers.Commands;
using CatologDomain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Catalog.ServiceEventHandlers
{
    public class ProductCreateEventHandler:INotificationHandler<ProductCreateCommand>
    {

        private readonly AplicationDBContext _context;

        public ProductCreateEventHandler(AplicationDBContext context)
        {
            _context = context;
        }

        public async Task Handle(ProductCreateCommand command, CancellationToken cancellationToken)
        {
            await _context.AddAsync(new Product
            {
                NameProduct = command.Name,
                Price = command.Price,
                DescriptionProduct = command.Description,
            });

            await _context.SaveChangesAsync();
        }

       
    }
}
