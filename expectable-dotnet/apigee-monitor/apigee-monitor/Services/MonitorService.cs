using apigee_monitor.Models;
using apigee_monitor.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace apigee_monitor.Services
{
    public class MonitorService : IMonitorService
    {
        private readonly IServerRepository _serverRepository;
        private readonly IServiceRepository _serviceRepository;
        private readonly IApigeeClient _apigeeClient;

        public MonitorService(IServerRepository serverRepository,
            IServiceRepository serviceRepository,
            IApigeeClient apigeeClient)
        {
            _serverRepository = serverRepository;
            _serviceRepository = serviceRepository;
            _apigeeClient = apigeeClient;
        }

        public List<Service> ServiceStatus(string serverId)
        {
            List<Service> services = new List<Service>();

            //get server by serverId
            var server = _serverRepository.GetServer(serverId);

            //make sure server with services exists
            if (server != null && server.Services != null)
            {
                //loop through server services
                foreach (var serviceId in server.Services)
                {
                    //get service status
                    var service = ServiceStatus(server, serviceId);
                    if (service != null)
                    {
                        services.Add(service);
                    }
                }
            }

            return services;
        }

        public Service ServiceStatus(string serverId, string serviceId)
        {
            //get server by serverId
            var server = _serverRepository.GetServer(serverId);

            //get service status
            return ServiceStatus(server, serviceId);
        }

        private Service ServiceStatus(Server server, string serviceId)
        {
            //make sure server with services exists and service is valid for the server
            if (server != null &&
                server.Services != null &&
                server.Services.Contains(serviceId))
            {
                //get service from serviceId
                var service = _serviceRepository.GetService(serviceId);
                if (service != null)
                {
                    //check if service is running on host
                    service.Running = _apigeeClient.IsServiceRunning(server.Url, service.Port);
                    return service;
                }
            }

            return null;
        }

       
    }
}
