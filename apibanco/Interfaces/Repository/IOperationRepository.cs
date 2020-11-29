using apibanco.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apibanco.Interfaces.Repository
{
    public interface IOperationRepository
    {

        /// <summary>
        /// Metodo que verifica se o hash já existe
        /// </summary>
        /// <param name="hash"></param>
        string GetByHash(string hash);

        /// <summary>
        /// Metodo que insere os depositos, saques e transferências no banco
        /// </summary>
        /// <param name="operation"></param>
        void InsertOperation(Operation operation);

        /// <summary>
        /// Metodo que recupera o IdAccount a partir do hash informado
        /// </summary>
        /// <param name="hash"></param>
        int GetIdAccountByHash(string hash);
    }
}
