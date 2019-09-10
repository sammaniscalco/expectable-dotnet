using apigee_monitor.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apigee_monitor.Repository
{
    public class ServiceList:IServiceRepository
    {
        private readonly List<Service> _context;

        public ServiceList(IOptions<List<Service>> context)
        {
            _context = context.Value;
        }

        public IEnumerable<Service> GetServices()
        {
            return _context;
        }

        public IEnumerable<Service> GetServices(IEnumerable<string> services)
        {
            return _context.Where(c => services.Contains(c.Id));
        }

        public Service GetService(string id)
        {
            return _context.FirstOrDefault(c => c.Id == id);
        }
    }
}
