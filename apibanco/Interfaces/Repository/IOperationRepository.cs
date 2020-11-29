using apibanco.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apibanco.Interfaces.Repository
{
    public interface IOperationRepository
    {
        string GetByHash(string hash);

        void InsertOperation(Operation operation);

        int GetIdAccountByHash(string hash);
    }
}
