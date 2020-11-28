using apibanco.Interfaces.Repository;
using apibanco.Interfaces.Service;
using apibanco.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apibanco.Services
{
    public class OperationService : IOperationService
    {
        private readonly IOperationRepository _repository;

        public OperationService(IOperationRepository repository)
        {
            _repository = repository;
        }
        public string GetByHash(string hash)
        {
            return _repository.GetByHash(hash);
        }
    }
}
