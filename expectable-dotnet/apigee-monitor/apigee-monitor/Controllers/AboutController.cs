using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apigee_monitor.Models;
using Microsoft.AspNetCore.Mvc;

namespace apigee_monitor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        public AboutController()
        {

        }

        // GET api/values
        [HttpGet]
        public ActionResult<About> Get()
        {
            return new About() { Name = "apigee-monitor", Version = "1.0.0" };
        }
    }
}
