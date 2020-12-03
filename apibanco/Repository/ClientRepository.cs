using apibanco.Interfaces.Repository;
using apibanco.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

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
        /// Metodo para inclusao clientes no banco de dados
        /// </summary>
        /// <param name="client"></param>
        public void Insert(Client client)
        {
            var connection = new SqlConnection(_connectionString);

            var query = @"INSERT INTO [Cliente] ([Nome],[CPF])
                                VALUES (@Nome, @CPF)";

            connection.Execute(query, new
            {
                Nome = client.Nome,
                CPF = client.CPF
            });
        }
    }
}
