using apigee_monitor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apigee_monitor.Repository
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly ServiceContext _context;

        public ServiceRepository(ServiceContext context)
        {
            _context = context;
        }

        public IEnumerable<Service> GetServices()
        {
            return _context.Services.ToList();
        }

        public IEnumerable<Service> GetServices(IEnumerable<string> services)
        {
            return _context.Services.Where(c=> services.Contains(c.Id));
        }

        public Service GetService(string id)
        {
            return _context.Services.Find(id);
        }
    }
}
