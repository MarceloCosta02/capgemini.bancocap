using System;

namespace apibanco.Models
{
    public class Operation : Base
    {
        public char Type { get; set; }
        public double Value { get; set; }
        public DateTime DataHora { get; set; }
        public int? IdContaOrigem { get; set; }
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
