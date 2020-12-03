using apibanco.Interfaces.Repository;
using apibanco.Interfaces.Service;
using apibanco.Models;
using System;
using System.Linq;

namespace apibanco.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _repo;

        public AccountService(IAccountRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Metodo para inclusao de Contas no banco de dados
        /// </summary>
        /// <param name="account"></param>
        public string InsertAccount(Account account)
        {
            bool validateHash = false;
            string hash = "";

            while (!validateHash)
            {
                hash = GenerateHash();
                validateHash = VerifyIfHashExists(hash);
            }

            account.Hash = hash;
            _repo.Insert(account);

            return $"Código Hash {hash} criado com sucesso";
        }

        /// <summary>
        /// Metodo que verifica se o hash existe já no banco
        /// </summary>
        /// <param name="hash"></param>
        public bool VerifyIfHashExists(string hash)
        {
            var exists = _repo.VerifyIfHashExists(hash);
            if (exists == 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Metodo que gera o hash da conta
        /// </summary>
        private string GenerateHash()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUWXYZ123456789";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, 8)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            return result;
        }

    }
}
