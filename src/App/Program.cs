using System;
using System.Data;
using System.Data.SqlClient;
using App.Enums;
using App.Interfaces;
using Dapper;
using Npgsql;
using Oracle.ManagedDataAccess.Client;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            var dbSettings = new DbSettings();
            dbSettings.Provider = EProvider.Postgresql;
            dbSettings.ConnectionString = "Server=localhost;Port=5501;Database=postgres;User Id=postgres;Password=postgres;";
            dbSettings.Commmand = "select p.name from adonet.product p limit 1";
            dbSettings.CommandResponseType = ECommandResponseType.ExecuteScalar;

            Execute(dbSettings);

            Console.WriteLine(dbSettings.ExecuteScalarResponse);
        }

        static void Execute(DbSettings dbSettings)
        {
            IDbConnection connection;

            switch (dbSettings.Provider)
            {
                case EProvider.SqlServer:
                    connection = new SqlConnection(dbSettings.ConnectionString);
                    break;

                case EProvider.Postgresql:
                    connection = new NpgsqlConnection(dbSettings.ConnectionString);
                    break;

                case EProvider.Oracle:
                    connection = new OracleConnection(dbSettings.ConnectionString);
                    break;

                default:
                    return;
            }

            ExecuteCommand(dbSettings, connection);
        }

        static void ExecuteCommand(DbSettings dbSettings, IDbConnection connection)
        {
            IUnitOfWork unitOfWork = new UnitOfWork(connection);

            unitOfWork.BeginTransaction();

            var dbCommand = unitOfWork.CreateCommand(dbSettings.CommandType, dbSettings.Commmand);

            switch (dbSettings.CommandResponseType)
            {
                case ECommandResponseType.ExecuteNonQuery:
                    dbSettings.ExecuteNonQueryResponse = dbCommand.ExecuteNonQuery();
                    break;

                case ECommandResponseType.ExecuteScalar:
                    dbSettings.ExecuteScalarResponse = (string)dbCommand.ExecuteScalar();
                    break;

                case ECommandResponseType.DataReader:
                    dbSettings.DataReaderResponse = dbCommand.ExecuteReader();
                    break;

                default:
                    return;
            }
        }
    }
}
