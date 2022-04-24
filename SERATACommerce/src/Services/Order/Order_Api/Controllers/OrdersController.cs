using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Order.ServiceEventeHandlers.Commands;
using Product.QueryService;
using Product.QueryService.Dtos;
using Service.CommonPaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_Api.Controllers
{

    [ApiController]
    [Route("orders")]
    public class OrdersController : ControllerBase
    {
        private readonly ILogger<OrdersController> _logger;
        private readonly IProductQueryService _productQueryService;
        private readonly IMediator _mediator;
        public OrdersController(ILogger<OrdersController> logger, IProductQueryService productQueryService, IMediator mediator)
        {
            _logger = logger;
            _productQueryService = productQueryService;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<DataCollection<OrderDetailDto>> Get(int page, int take, string ids = null)
        {
            IEnumerable<int> idsQuery = null;

            if (!string.IsNullOrEmpty(ids))
            {
                idsQuery = ids.Split(',').Select(x => Convert.ToInt32(x));
            }

            return await _productQueryService.Get(page, take, idsQuery);


        }



        [HttpPost]
        public async Task<ActionResult> CreateOrder(OrderCreateCommand command)
        {
            await _mediator.Publish(command);
            return Ok();


        }


    }

}

