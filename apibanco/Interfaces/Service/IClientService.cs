using apibanco.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apibanco.Interfaces.Service
{
    public interface IClientService
    {
        void InsertClient(Client client);
    }
}
