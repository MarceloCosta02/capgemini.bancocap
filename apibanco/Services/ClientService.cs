using apibanco.Interfaces.Repository;
using apibanco.Interfaces.Service;
using apibanco.Models;

namespace apibanco.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _repository;

        public ClientService(IClientRepository repository)
        {
            _repository = repository;
        }

        public void InsertClient(Client client)
        {
            _repository.Insert(client);
        }
    }
}
