using apibanco.Models;

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
