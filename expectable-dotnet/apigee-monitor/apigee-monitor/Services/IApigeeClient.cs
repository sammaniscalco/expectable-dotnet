using apigee_monitor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace apigee_monitor.Services
{
    public interface IApigeeClient
    {
        bool IsServiceRunning(string url, int port);
    }
}
