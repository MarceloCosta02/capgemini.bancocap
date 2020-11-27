using apibanco.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apibanco.Interfaces.Repository
{
    public interface IAccountRepository
    {
        /// <summary>
        /// Metodo para inclusao de Contas no banco de dados
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        void Insert(Account account);

        /// <summary>
        /// Metodo que verifica se o hash existe já no banco
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        int VerifyIfHashExists(string hash);
    }
}
