using System;
using System.Data;

namespace App.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {        
        IDbTransaction _transaction { get; set; }
        IDbConnection _connection { get; set; }
        IDbCommand CreateCommand(string commandText);
        int Execute(string commandText);
        IDataReader Query(string commandText);
        string QuerySingle(string commandText);
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}