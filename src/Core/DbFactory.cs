using System;
using System.Data;
using System.Data.SqlClient;
using Core.Enums;
using Core.Interfaces;
using Npgsql;
using Oracle.ManagedDataAccess.Client;

namespace Core
{
    public class DbFactory : IDbFactory
    {
        public DbFactory(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public string ConnectionString { get; set; }
        public EDataBaseProvider EDataBaseProvider { get; set; }

        /// <summary>
        /// Retorna a conexão com um provedor específico        
        /// </summary>
        public IDbConnection CreateConector(EDataBaseProvider dataBaseProvider) => dataBaseProvider switch
        {
            EDataBaseProvider.SqlServer => new SqlConnection(ConnectionString),
            EDataBaseProvider.Postgresql => new NpgsqlConnection(ConnectionString),
            EDataBaseProvider.Oracle => new OracleConnection(ConnectionString),
            _ => throw new ArgumentOutOfRangeException(nameof(dataBaseProvider), $"Not expected direction value: {dataBaseProvider}"),
        };
    }
}