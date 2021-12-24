using System;
using System.Data;
using System.Data.SqlClient;
using App.Enums;
using App.Interfaces;
using Npgsql;
using Oracle.ManagedDataAccess.Client;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            var dbSettings = new DbSettings().GetSqlServerDbSettings();            
            Execute(dbSettings);

            Console.WriteLine(dbSettings.RespostaTexto);
            //Console.WriteLine(dbSettings.RespostaInteiro);
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

            var dbCommand = unitOfWork.CreateCommand(dbSettings.CommandType, dbSettings.Comando); 

            switch (dbSettings.ReturnCommamndType)
            {
                case EReturnCommamndType.ExecuteNonQuery:
                    dbSettings.RespostaInteiro = dbCommand.ExecuteNonQuery();
                    break;

                case EReturnCommamndType.ExecuteScalar:
                    dbSettings.RespostaTexto = (string)dbCommand.ExecuteScalar();
                    break;

                case EReturnCommamndType.DataReader:
                    dbSettings.RespostaDataReader = dbCommand.ExecuteReader();
                    break;

                default:
                    return;
            }
        }
    }
}
