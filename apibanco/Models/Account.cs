using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace apibanco.Models
{
    public class Account
    {
        public int Id { get; set; }

        [JsonIgnore]
        public string Hash { get; set; }

        public int idCliente { get; set; }
    }
}
