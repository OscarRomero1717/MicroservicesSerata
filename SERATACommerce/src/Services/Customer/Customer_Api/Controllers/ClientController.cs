using Customer.Domain;
using Customer.QueryServices;
using Customer.ServiceEventHandler.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.CommonPaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer_Api.Controllers
{
    [ApiController]
    [Route("clients")]
    public class ClientController : ControllerBase
    {
       
       

        private readonly ICustomerService _customerService;
        private readonly IMediator _mediator;

        public ClientController( ICustomerService customerService, IMediator mediator)
        {
           
            _customerService = customerService;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<DataCollection<ClientDto>> GetAll(int page = 1, int take = 10, string ids = null)
        {
            IEnumerable<int> IdsEnumerable = null;

            if (!string.IsNullOrEmpty(ids))
            {
                IdsEnumerable = ids.Split(',').Select(x => Convert.ToInt32(x));
            }

            return await _customerService.Get(page, take, IdsEnumerable);
        }


        [HttpGet]
        [Route("{Id}")]
        public async Task<ClientDto> GetById(int id )
        {
            return await _customerService.GetByID(id);
        }


        [HttpPost]
        public async Task<ActionResult> CreateCliente(ClientCreateCommand command)
        {

            await _mediator.Publish(command);

            return Ok();


        }
    }
}
