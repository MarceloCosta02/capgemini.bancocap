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

        public void MakeOperations(Operation operation, string hash)
        {
            int idAccount = _repository.GetIdAccountByHash(hash);

            var newOperation = SetOperationValues(operation, idAccount);

            _repository.InsertOperation(newOperation);
        }

        public void MakeTransfer(Operation operation, string hashOrigin, string hashDestiny)
        {
            int idAccountOrigin = _repository.GetIdAccountByHash(hashOrigin);
            int idAccountDestiny = _repository.GetIdAccountByHash(hashDestiny);

            var newOperation = SetTransferValues(operation, idAccountOrigin, idAccountDestiny);

            _repository.InsertOperation(newOperation);
        }

        private Operation SetOperationValues(Operation operation, int idAccount)
        {
            operation.DataHora = DateTime.Now;

            if (operation.Type == 'D')
            {
                operation.IdContaDestino = idAccount;
                operation.IdContaOrigem = 0;
                return operation;
            }
            else if (operation.Type == 'S')
            {
                operation.IdContaDestino = 0;
                operation.IdContaOrigem = idAccount;
                operation.DataHora = DateTime.Now;
                return operation;
            }          
            else
                throw new Exception($" {operation.Type} não é um tipo de operação válido, favor indicar D para Depósito e S para Saque");
        }

        private Operation SetTransferValues(Operation operation, int idAccountOrigin, int idAccountDestiny)
        {
            operation.DataHora = DateTime.Now;
            operation.IdContaDestino = idAccountDestiny;
            operation.IdContaOrigem = idAccountOrigin;
            operation.Type = 'T';
            operation.DataHora = DateTime.Now;
            return operation;
        }
    }
}
