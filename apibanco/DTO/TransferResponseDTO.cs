using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apibanco.DTO
{
    public class TransferResponseDTO
    {
        public TransferResponseDTO(string message, int status)
        {
            Message = message;
            Status = status;
        }

        public string Message { get; set; }
        public int Status { get; set; }
    }
}
