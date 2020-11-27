using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apibanco.Models
{
    public class Operation
    {
        public string Hash { get; set; }
        public char Type { get; set; }
        public double Value { get; set; }
        public DateTime DataHora { get; set; }
        public int IdContaOrigem { get; set; }
        public int IdContaDestino { get; set; }

    }
}
