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
    public class ClientRepository : IClientRepository
    {
        private readonly string _connectionString;
        public ClientRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        /// <summary>
        /// Incluindo o cliente no banco
        /// </summary>
        /// <param name="client"></param>
        public void Insert(Client client)
        {
            var connection = new SqlConnection(_connectionString);

            var query = @"INSERT INTO [Cliente] ([Nome],[CPF])
                                VALUES (@Nome, @CPF)";

            var result = connection.Execute(query, new
            {
                Nome = client.Nome,
                CPF = client.CPF
            });
        }
    }
}
