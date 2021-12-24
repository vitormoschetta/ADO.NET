using System;
using System.Data;
using System.Data.SqlClient;
using Npgsql;
using Oracle.ManagedDataAccess.Client;

namespace App
{
    public enum EProvider
    {
        SqlServer = 1,
        Postgresql = 2,
        Oracle = 3
    }

    public static class Provider
    {
        /// <summary>
        /// Retorna a conexão com um provedor específico        
        /// </summary>        
        public static IDbConnection GetProviderConnection(DbConnectionInfo dbConnectionInfo) => dbConnectionInfo.Provider switch
        {
            EProvider.SqlServer => new SqlConnection(dbConnectionInfo.ConnectionString),
            EProvider.Postgresql => new NpgsqlConnection(dbConnectionInfo.ConnectionString),
            EProvider.Oracle => new OracleConnection(dbConnectionInfo.ConnectionString),
            _ => throw new ArgumentOutOfRangeException(nameof(dbConnectionInfo.Provider), $"Not expected direction value: {dbConnectionInfo.Provider}"),
        };
    }
}