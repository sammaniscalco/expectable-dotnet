using apigee_monitor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace apigee_monitor.Services
{
    public class ApigeeRandomClient:IApigeeClient
    {
        public ApigeeRandomClient()
        {
        }

        public bool IsServiceRunning(string url, int port)
        {
            //random number 0 or 1
            var rand = new Random();
            var num = rand.Next(0, 2);

            //return bool
            return num == 1 ? true : false;

        }
    }
}
