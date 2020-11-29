using System;
using System.Text.Json.Serialization;

namespace apibanco.Models
{
    public class Operation 
    {
        public char Type { get; set; }
        public double Value { get; set; }

        [JsonIgnore]
        public DateTime DataHora { get; set; }

        [JsonIgnore]
        public int? IdContaOrigem { get; set; }

        [JsonIgnore]
        public int? IdContaDestino { get; set; }

        public Operation(char type, double value, DateTime dataHora, int? idContaOrigem, int? idContaDestino)
        {
            Type = type;
            Value = value;
            DataHora = dataHora;
            IdContaOrigem = idContaOrigem;
            IdContaDestino = idContaDestino;
        }
    }
}
