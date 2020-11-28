using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apibanco.Interfaces.Repository
{
    public interface IOperationRepository
    {
        string GetByHash(string hash);
    }
}
