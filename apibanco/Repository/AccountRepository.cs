using apibanco.Interfaces.Repository;
using apibanco.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace apibanco.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly string _connectionString;

        public AccountRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        /// <summary>
        /// Metodo para inclusao de Contas no banco de dados
        /// </summary>
        /// <param name="account"></param>
        public void Insert(Account account)
        {
            var connection = new SqlConnection(_connectionString);

            var query = "insert into conta (Hash, IdCliente) " +
                            "values (@Hash, @IdCliente)";

            var result = connection.Execute(query, new
            {
                Hash = account.Hash,
                IdCliente = account.IdCliente
            });
        }

        /// <summary>
        /// Metodo que verifica se o hash existe já no banco
        /// </summary>
        /// <param name="hash"></param>
        public int VerifyIfHashExists(string hash)
        {
            var connection = new SqlConnection(_connectionString);

            var query = "select count(Hash) from conta " +                           
                            " where Hash = @Hash";

            var result = connection.Query<int>(query, new { Hash = hash });

            return result.FirstOrDefault();
        }
    }
}
