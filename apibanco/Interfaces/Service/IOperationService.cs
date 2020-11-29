using apibanco.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apibanco.Interfaces.Service
{
    public interface IOperationService
    {
        string GetByHash(string hash);

        void MakeOperations(Operation operation, string hash);

        void MakeTransfer(Operation operation, string hashOrigin, string hashDestiny);
    }
}
