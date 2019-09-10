using apigee_monitor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apigee_monitor.Repository
{
    public interface IServerRepository
    {
        IEnumerable<Server> GetServers();
        Server GetServer(string id);
    }
}
