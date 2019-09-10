using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apigee_monitor.Models;
using apigee_monitor.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace apigee_monitor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServersController : ControllerBase
    {
        private readonly IServerRepository _serverRepository;
        public ServersController(IServerRepository serverRepository)
        {
            _serverRepository = serverRepository;
        }

        // GET: api/Servers
        [HttpGet]
        public ActionResult<IEnumerable<Server>> Get()
        {
            return Ok(_serverRepository.GetServers());
        }

        // GET: api/Servers/5
        [HttpGet("{id}")]
        public ActionResult<Server> Get(string id)
        {
            var server = _serverRepository.GetServer(id);

            //make sure server exists
            if (server != null)
            {
                return Ok(server);
            }
            else
            {
                return NotFound();
            }
        }
    }
}