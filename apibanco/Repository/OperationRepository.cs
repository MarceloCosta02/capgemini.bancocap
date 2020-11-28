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
    }
}

