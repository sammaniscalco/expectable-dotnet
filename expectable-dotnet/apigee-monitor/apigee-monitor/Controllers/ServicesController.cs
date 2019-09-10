using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apigee_monitor.Models;
using apigee_monitor.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace apigee_monitor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IServiceRepository _serviceRepository;
        public ServicesController(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        // GET: api/Services
        [HttpGet]
        public ActionResult<IEnumerable<Service>> Get()
        {
            return Ok(_serviceRepository.GetServices());
        }

        // GET: api/Services/5
        [HttpGet("{id}")]
        public ActionResult<Service> Get(string id)
        {
            var service = _serviceRepository.GetService(id);

            //make sure service exists
            if (service != null)
            {
                return Ok(service);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
