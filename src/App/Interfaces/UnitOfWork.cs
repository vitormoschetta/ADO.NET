using System;
using System.Data;

namespace App.Interfaces
{
    public class UnitOfWork : IUnitOfWork
    {
        public IDbTransaction _transaction { get; set; }
        public IDbConnection _connection { get; set; }

        public UnitOfWork(IDbConnection connection)
        {
            _connection = connection;
        }

        public IDbCommand CreateCommand()
        {
            var command = _connection.CreateCommand();
            command.Transaction = _transaction;
            return command;
        }

        public void Dispose()
        {
            _transaction.Dispose();
            _connection.Close();
            GC.SuppressFinalize(this);
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
    }
}