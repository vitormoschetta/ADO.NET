using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using Core;
using Core.Enums;
using Core.Interfaces;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            var connStr = "Server=localhost;Port=5501;Database=postgres;User Id=postgres;Password=postgres;";
            var dbConnectionSettings = new DbConnectionSettings(connStr, EDataBaseProvider.Postgresql);

            IDbConnection dbConnection = DataBaseProvider.GetProviderConnection(dbConnectionSettings);

            DeleteNewProducts(dbConnection);
            PrintProductQuantities(dbConnection);
            Sample01(dbConnection);
            Sample02(dbConnection);
            Sample03(dbConnection);
            PrintProductQuantities(dbConnection);
            PrintProducts(dbConnection);
        }


        // Exemplo de comando sem usar transação:
        static void Sample01(IDbConnection dbConnection)
        {
            IUnitOfWork uow = new UnitOfWork(dbConnection);

            var response = uow.Execute("insert into adonet.product (name, price) values('manteiga', 14.90)");
            Console.WriteLine(response == 1 ? "\nProduto registrado com sucesso" : "Falha ao registrar Produto");

            Thread.Sleep(1000);
        }


        // Exemplo de comando usando transação:
        static void Sample02(IDbConnection dbConnection)
        {
            IUnitOfWork uow = new UnitOfWork(dbConnection);

            uow.BeginTransaction();

            try
            {
                var response = uow.Execute("insert into adonet.product (name, price) values('feijão', 7.90)");
                Console.WriteLine(response == 1 ? "\nProduto registrado com sucesso" : "Falha ao registrar Produto");

                uow.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro: " + ex.Message);
                Console.WriteLine("Desafazendo transação..");
                uow.Rollback();
            }

            Thread.Sleep(1000);
        }


        // Exemplo de comando usando transação, gerando exceção e fazendo rollback.
        // O primeiro produto será registrado com sucesso, porém o segundo irá gerar uma exceção, 
        // fazendo rollback  e cancelando o registro do primeiro:
        static void Sample03(IDbConnection dbConnection)
        {
            IUnitOfWork uow = new UnitOfWork(dbConnection);

            uow.BeginTransaction();

            try
            {
                var response = uow.Execute("insert into adonet.product (name, price) values('macarrão', 3.75)");
                Console.WriteLine(response == 1 ? "\nProduto registrado com sucesso" : "Falha ao registrar Produto");

                response = uow.Execute("insert into adonet.product (name, price) values('macarrão', 3.75)");
                Console.WriteLine(response == 1 ? "\nProduto registrado com sucesso" : "Falha ao registrar Produto");

                uow.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nOcorreu um erro: " + ex.Message);
                Console.WriteLine("\nDesafazendo transação..");
                uow.Rollback();
            }

            Thread.Sleep(1000);
        }


        // Exemplo de consulta Scalar:
        static void PrintProductQuantities(IDbConnection dbConnection)
        {
            IUnitOfWork uow = new UnitOfWork(dbConnection);

            var response = uow.QueryScalar("select count(*) from adonet.product");
            Console.WriteLine("\nQuantidade atual de produtos: " + response);

            Thread.Sleep(1000);
        }


        static void PrintProduct(IDbConnection dbConnection)
        {
            IUnitOfWork uow = new UnitOfWork(dbConnection);

            var product = uow.QuerySingle<Product>("select * from adonet.product where id = 1");

            Console.WriteLine($"{product.Id} - {product.Name} - {product.Price}");
        }


        static void PrintProducts(IDbConnection dbConnection)
        {
            IUnitOfWork uow = new UnitOfWork(dbConnection);

            var products = uow.QueryList<IEnumerable<Product>>("select * from adonet.product");

            foreach (var product in products)
            {
                Console.WriteLine($"{product.Id} - {product.Name} - {product.Price}");
            }
        }


        static void DeleteNewProducts(IDbConnection dbConnection)
        {
            IUnitOfWork uow = new UnitOfWork(dbConnection);

            uow.Execute("delete from adonet.product p where p.id > 3");           
        }

    }
}
