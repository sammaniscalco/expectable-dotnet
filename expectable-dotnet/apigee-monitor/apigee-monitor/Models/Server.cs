using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apigee_monitor.Models
{
    public class Server
    {
        public string Id { get; set; }
        public string Url { get; set; }
        public List<string> Services { get; set; }
    }
}
