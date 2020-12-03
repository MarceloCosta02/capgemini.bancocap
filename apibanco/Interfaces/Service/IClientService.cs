using apibanco.Models;

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
