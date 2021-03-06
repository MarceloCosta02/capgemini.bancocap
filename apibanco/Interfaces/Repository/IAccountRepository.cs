﻿using apibanco.Models;

namespace apibanco.Interfaces.Repository
{
    public interface IAccountRepository
    {
        /// <summary>
        /// Metodo para inclusao de Contas no banco de dados
        /// </summary>
        /// <param name="account"></param>
        void Insert(Account account);

        /// <summary>
        /// Metodo que verifica se o hash existe já no banco
        /// </summary>
        /// <param name="hash"></param>
        int VerifyIfHashExists(string hash);
    }
}
