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
        /// <summary>
        /// Metodo para inclusao clientes no banco de dados
        /// </summary>
        /// <param name="client"></param>
        void Insert(Client client);
    }
}
