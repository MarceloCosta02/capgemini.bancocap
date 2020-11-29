using apibanco.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apibanco.Interfaces.Service
{
    public interface IClientService
    {
        /// <summary>
        /// Metodo que insere clientes no banco
        /// </summary>
        /// <param name="client"></param>
        void InsertClient(Client client);
    }
}
