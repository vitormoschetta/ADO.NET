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
            var operacao = new Operacao()
            {
                ConnectionString = "Server=localhost;Database=master;User=sa;Password=Pass123*;",
                Comando = "SELECT @@version",
                Provider = EProvider.SqlServer,
                CommandType = CommandType.Text,
                ReturnCommamndType = EReturnCommamndType.ExecuteScalar
            };

            Execute(operacao);

            Console.WriteLine(operacao.RespostaTexto);
        }

        static void Execute(Operacao operacao)
        {
            IDbConnection connection;            

            switch (operacao.Provider)
            {
                case EProvider.SqlServer:
                    connection = new SqlConnection(operacao.ConnectionString);
                    break;

                case EProvider.Postgresql:
                    connection = new NpgsqlConnection(operacao.ConnectionString);
                    break;

                case EProvider.Oracle:
                    connection = new OracleConnection(operacao.ConnectionString);
                    break;

                default:
                    return;
            }

            ExecuteCommand(operacao, connection);
        }

        static void ExecuteCommand(Operacao operacao, IDbConnection connection)
        {
            IUnitOfWork unitOfWork = new UnitOfWork(connection);

            unitOfWork.BeginTransaction();

            var dbCommand = unitOfWork.CreateCommand();

            dbCommand.CommandType = operacao.CommandType;
            dbCommand.CommandText = operacao.Comando;

            switch (operacao.ReturnCommamndType)
            {
                case EReturnCommamndType.ExecuteNonQuery:
                    operacao.RespostaInteiro = dbCommand.ExecuteNonQuery();
                    break;

                case EReturnCommamndType.ExecuteScalar:
                    operacao.RespostaTexto = (string)dbCommand.ExecuteScalar();
                    break;

                case EReturnCommamndType.DataReader:
                    operacao.RespostaDataReader = dbCommand.ExecuteReader();
                    break;

                default:
                    return;
            }
        }
    }

    public class Operacao
    {
        public string ConnectionString { get; set; }
        public string Comando { get; set; }
        public EProvider Provider { get; set; }
        public CommandType CommandType { get; set; }
        public EReturnCommamndType ReturnCommamndType { get; set; }
        public string RespostaTexto { get; set; }
        public int RespostaInteiro { get; set; }
        public IDataReader RespostaDataReader { get; set; }
    }
}
