using System;
using System.Data;

namespace App.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {        
        IDbTransaction _transaction { get; set; }
        IDbConnection _connection { get; set; }
        IDbCommand CreateCommand();
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}