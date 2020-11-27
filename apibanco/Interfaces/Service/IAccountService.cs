using apibanco.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apibanco.Interfaces.Service
{
    interface IAccountService
    {
        /// <summary>
        /// Metodo para inclusao de Contas no banco de dados
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        void InsertAccount(Account account);
    }
}
