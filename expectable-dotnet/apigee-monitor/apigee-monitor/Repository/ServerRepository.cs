using apigee_monitor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apigee_monitor.Repository
{
    public class ServerRepository : IServerRepository
    {
        private readonly ServerContext _context;
        
        public ServerRepository(ServerContext context)
        {
            _context = context;
        }

        public IEnumerable<Server> GetServers()
        {
            return _context.Servers.ToList();
        }

        public Server GetServer(string id)
        {
            return _context.Servers.Find(id);
        }
    }
}
