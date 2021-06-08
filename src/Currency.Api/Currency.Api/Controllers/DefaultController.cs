using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Currency.Api.Controllers
{

    [ApiController]
    [Route("/")]
    public class DefaultController : ControllerBase
    {
        public DefaultController() { }
        
        [HttpGet]
        public string Get()
        {
            return "Running ..";
        }
    }
}
