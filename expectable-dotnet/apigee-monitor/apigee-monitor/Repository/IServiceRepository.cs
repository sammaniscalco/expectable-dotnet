using apigee_monitor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apigee_monitor.Repository
{
    public interface IServiceRepository
    {
        IEnumerable<Service> GetServices();
        IEnumerable<Service> GetServices(IEnumerable<string> services);
        Service GetService(string id);
    }
}
