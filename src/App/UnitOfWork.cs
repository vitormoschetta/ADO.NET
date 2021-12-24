using System;
using System.Data;
using App.Interfaces;

namespace App
{
    public class UnitOfWork : IUnitOfWork
    {
        public IDbTransaction _transaction { get; set; }
        public IDbConnection _connection { get; set; }

        public UnitOfWork(IDbConnection connection)
        {
            _connection = connection;
        }

        public IDbCommand CreateCommand(string commandText)
        {
            var command = _connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = commandText;
            command.Transaction = _transaction;
            return command;
        }

        public int Execute(string commandText)
        {
            var command = CreateCommand(commandText);
            return command.ExecuteNonQuery();
        }

        public IDataReader Query(string commandText)
        {
            var command = CreateCommand(commandText);
            return command.ExecuteReader();
        }

        public string QuerySingle(string commandText)
        {
            var command = CreateCommand(commandText);
            return (string)command.ExecuteScalar();
        }

        public void BeginTransaction()
        {
            if (_transaction == null)
            {
                _connection.Open();
                _transaction = _connection.BeginTransaction();
            }
        }

        public void Commit()
        {
            if (_transaction == null)
            {
                throw new InvalidOperationException("A transação já foi comitada");
            }

            _transaction.Commit();
            Dispose();
        }

        public void Rollback()
        {
            if (_transaction != null)
            {
                _transaction.Rollback();
                Dispose();
            }
        }

        public void Dispose()
        {
            _transaction.Dispose();
            _connection.Close();
            GC.SuppressFinalize(this);
        }
    }
}