using Catalog.ServiceEventHandlers.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Catalog_API.Controllers
{
    [ApiController]
    [Route("Stocks")]
    public class ProductInStockController :ControllerBase
    {
        private readonly IMediator _mediator;
      


        public ProductInStockController(IMediator mediator, ILogger<ProductInStockController> logger) 
        {
            _mediator=  mediator;
          
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductInStockUpdateCommand command)
        {
            await _mediator.Publish(command);
            return Ok();
        }
    }
}
