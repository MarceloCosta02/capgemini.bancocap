using System.Text.Json.Serialization;

namespace apibanco.Models
{
    public class Account
    { 
        [JsonIgnore]
        public string Hash { get; set; }
        public int IdCliente { get; set; }

        public Account(string hash, int idCliente)
        {
            Hash = hash;
            IdCliente = idCliente;
        }
    }
}
