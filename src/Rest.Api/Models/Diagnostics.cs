using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rest.Models
{
    public class Diagnostics
    {
        public Diagnostics(string ip) {
            this.RequestIpAddress = ip;
        }

        public string RequestIpAddress { get; }
    }
}
