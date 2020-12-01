using apibanco.DTO;
using apibanco.Interfaces.Repository;
using apibanco.Interfaces.Service;
using apibanco.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace apibanco.Services
{
    public class OperationService : IOperationService
    {
        private readonly IOperationRepository _repository;
        private readonly IAccountRepository _accRepository;

        public OperationService(IOperationRepository repository, IAccountRepository accRepository)
        {
            _repository = repository;
            _accRepository = accRepository;
        }

        /// <summary>
        /// Metodo que verifica se o hash existe já no banco
        /// </summary>
        /// <param name="hash"></param>
        public string GetByHash(string hash)
        {
            return _repository.GetByHash(hash);
        }


        /// <summary>
        /// Metodo que realiza as operações de deposito e saque
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="hash"></param>
        public void MakeOperations(Operation operation, string hash)
        {
            int idAccount = _repository.GetIdAccountByHash(hash);

            var newOperation = SetOperationValues(operation, idAccount);

            _repository.InsertOperation(newOperation);
        }

        /// <summary>
        /// Metodo que realiza a operação de transferência
        /// </summary>
        /// <param name="transfer"></param>
        public TransferResponseDTO MakeTransfer(Transfer transfer)
        {
            var resultHashClient = _accRepository.VerifyIfHashExists(transfer.Hash);
            var resultHashBank = _accRepository.VerifyIfHashExists(transfer.HashBank);

            if (resultHashBank == 0)            
                throw new Exception("O Hash do Banco não está cadastrado");            
            if (resultHashClient == 0)            
                throw new Exception("O Hash do Cliente não está cadastrado");            
            else
            {
                int idAccountOrigin = _repository.GetIdAccountByHash(transfer.Hash);
                int idAccountDestiny = _repository.GetIdAccountByHash(transfer.HashBank);

                var newOperation = SetTransferValues(transfer, idAccountOrigin, idAccountDestiny);

                _repository.InsertOperation(newOperation);
                return new TransferResponseDTO("Transferência realizada", "201");
            }        
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

        private Operation SetTransferValues(Transfer transfer, int idAccountOrigin, int idAccountDestiny)
        {
            Operation operation = new Operation('T', transfer.TotalValue, DateTime.Now, idAccountOrigin, idAccountDestiny);          
            return operation;
        }
    }
}
