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
    public class OperationRepository : IOperationRepository
    {
        private readonly string _connectionString;
        public OperationRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        /// <summary>
        /// Metodo que verifica se o hash já existe
        /// </summary>
        /// <param name="hash"></param>
        public string GetByHash(string hash)
        {
            var connection = new SqlConnection(_connectionString);

            var query = connection.Query<string>(@$"DECLARE @CONTA int
                                                    SET @CONTA = (SELECT ID FROM CONTA WHERE HASH = '{hash}')
                                                    SELECT DISTINCT
                                                        ((ISNULL((select VALOR from OPERACAO where IDCONTADESTINO = @CONTA and TIPO ='D'),0)) +
                                                         (ISNULL((select VALOR from OPERACAO where IDCONTAORIGEM = @CONTA and TIPO ='S'),0)) +
                                                         (ISNULL((select VALOR from OPERACAO where IDCONTAORIGEM = @CONTA and TIPO ='T'),0 )) +
                                                         (ISNULL((select VALOR from OPERACAO where IDCONTADESTINO = @CONTA and TIPO = 'T'),0 ))) AS SALDO 

                                                    FROM OPERACAO").FirstOrDefault();
            return query.ToString();
        }

        /// <summary>
        /// Metodo que insere os depositos, saques e transferências no banco
        /// </summary>
        /// <param name="operation"></param>
        public void InsertOperation(Operation operation)
        {
            var connection = new SqlConnection(_connectionString);

            var query = "insert into operacao (DataHora, Valor, Tipo, IdContaOrigem, IdContaDestino) " +
                            "values (@DataHora, @Valor, @Tipo, @IdContaOrigem, @IdContaDestino)";

            var result = connection.Execute(query, new
            {
                DataHora = operation.DataHora,
                Valor = operation.Value,
                Tipo = operation.Type,
                IdContaOrigem = operation.IdContaOrigem,
                IdContaDestino = operation.IdContaDestino
            });
        }

        /// <summary>
        /// Metodo que recupera o IdAccount a partir do hash informado
        /// </summary>
        /// <param name="hash"></param>
        public int GetIdAccountByHash(string hash)
        {
            var connection = new SqlConnection(_connectionString);

            var query = "select Id from conta " +
                            " where Hash = @Hash";

            var result = connection.Query<int>(query, new { Hash = hash });

            return result.FirstOrDefault();
        }       
    }
}

