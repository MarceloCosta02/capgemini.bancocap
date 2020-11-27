using apibanco.Models;
using apibanco.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apibanco.Interfaces.Repository
{
    public interface IClientRepository
    {
        void Insert(Client client);
    }
}
