using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apibanco.Models
{
    public class Transfer
    {
        public string HashOrigin { get; set; }
        public string HashDestiny { get; set; }
        public double Value { get; set; }

    }
}
