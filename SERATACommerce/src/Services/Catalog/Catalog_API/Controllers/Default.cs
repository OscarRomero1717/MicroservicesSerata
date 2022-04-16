using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog_API.Controllers
{
    [ApiController]
    [Route("/")]
    public class Default : ControllerBase
    {
        
        [HttpGet]
        public string Get()
        {
            return "start up";
        }
    }
}
