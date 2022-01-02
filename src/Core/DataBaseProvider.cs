using System;
using System.Data;
using System.Data.SqlClient;
using Core.Enums;
using Npgsql;
using Oracle.ManagedDataAccess.Client;

namespace Core
{
    public class DataBaseProvider
    {
        /// <summary>
        /// Retorna a conexão com um provedor específico        
        /// </summary>        
        public static IDbConnection GetProviderConnection(DbConnectionSettings dbConnectionSettings) => dbConnectionSettings.DataBaseProvider switch
        {
            EDataBaseProvider.SqlServer => new SqlConnection(dbConnectionSettings.ConnectionString),
            EDataBaseProvider.Postgresql => new NpgsqlConnection(dbConnectionSettings.ConnectionString),
            EDataBaseProvider.Oracle => new OracleConnection(dbConnectionSettings.ConnectionString),
            _ => throw new ArgumentOutOfRangeException(nameof(dbConnectionSettings.DataBaseProvider), $"Not expected direction value: {dbConnectionSettings.DataBaseProvider}"),
        };
    }
}