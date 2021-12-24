using System;
using System.Data;
using App.Interfaces;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            var connStr = "Server=localhost;Port=5501;Database=postgres;User Id=postgres;Password=postgres;";
            var dbConnectionInfo = new DbConnectionInfo(connStr, EProvider.Postgresql);                 

            IDbConnection dbConnection = Provider.GetProviderConnection(dbConnectionInfo);
            IUnitOfWork uow = new UnitOfWork(dbConnection);

            uow.BeginTransaction();

            try
            {
                var response = uow.QuerySingle("select p.name from adonet.product p limit 1");
                // dbSettings.Response = unitOfWork.Query(dbSettings.CommandType, dbSettings.CommmandText);                
                // dbSettings.Response = unitOfWork.Execute(dbSettings.CommandType, dbSettings.CommmandText);
                Console.WriteLine(response);
                uow.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro: " + ex.Message);
                Console.WriteLine("Desafazendo transação..");
                uow.Rollback();
            }

        }

    }
}
