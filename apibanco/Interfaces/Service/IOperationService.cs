using apibanco.DTO;
using apibanco.Models;

namespace apibanco.Interfaces.Service
{
    public interface IOperationService
    {
        /// <summary>
        /// Metodo que verifica se o hash existe já no banco
        /// </summary>
        /// <param name="hash"></param>
        string GetByHash(string hash);

        /// <summary>
        /// Metodo que realiza as operações de deposito e saque
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="hash"></param>
        void MakeOperations(Operation operation, string hash);

        /// <summary>
        /// Metodo que realiza a operação de transferência
        /// </summary>
        /// <param name="transfer"></param>  
        TransferResponseDto MakeTransfer(Transfer transfer);
    }
}
