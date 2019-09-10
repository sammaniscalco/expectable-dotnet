using apigee_monitor.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace apigee_monitor.Services
{
    public interface IMonitorService
    {
        List<Service> ServiceStatus(string serverId);
        Service ServiceStatus(string serverId, string serviceId);
    }
}
