using Catalog.ServiceEventHandlers.Commands;
using Catalog.ServiceQuery;
using Catolog.ServiceQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Service.CommonCollection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog_API.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductController : ControllerBase
    {
        
        private readonly IProdctQueryService _proctQueryService;
        private readonly IMediator _mediator;
        public ProductController( IProdctQueryService proctQueryService, IMediator mediator)
        {
           
            _proctQueryService = proctQueryService;
            _mediator = mediator;


        }


        [HttpGet]
        [Route("{Id}")]
        public async Task<ProductDto> GetById(int Id )
        {

            return await _proctQueryService.GetByIdAsync(Id);
        }


        [HttpGet]
        public async Task<DataCollection<ProductDto>> Getall(int page = 1, int take = 10, string ids = null)
        {
            IEnumerable<int> IdsEnumerable = null;


            if (!string.IsNullOrEmpty(ids))
            {
                IdsEnumerable = ids.Split(',').Select(x => Convert.ToInt32(x));
            }

            return await _proctQueryService.GetAllAsync(page, take, IdsEnumerable);
        }


        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateCommand command)
        {
             await _mediator.Publish(command);
            return Ok();
        }
    }
}
