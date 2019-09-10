using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apigee_monitor.Models;
using apigee_monitor.Repository;
using apigee_monitor.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace apigee_monitor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonitorController : ControllerBase
    {
        private readonly IMonitorService _monitorService;
        public MonitorController(IMonitorService monitorService)
        {
            _monitorService = monitorService;
        }

        // GET: api/Monitor/5
        [HttpGet("{hostname}")]
        public ActionResult<IEnumerable<Service>> Get(string hostname)
        {
            //get all service statuses
            var services=_monitorService.ServiceStatus(hostname);

            //return result
            if (services != null)
            {
                return Ok(services);
            }
            else
            {
                return NotFound();
            }
        }

        // GET: api/Monitor/5
        [HttpGet("{hostname}/{serviceId}")]
        public ActionResult<Service> Get(string hostname, string serviceId)
        {
            //get service status
            var service = _monitorService.ServiceStatus(hostname, serviceId);

            //return result
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