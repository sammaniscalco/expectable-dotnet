using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace apigee_monitor.Models
{
    public class Service
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Port { get; set; }
        public bool Running { get; set; }
    }
}
