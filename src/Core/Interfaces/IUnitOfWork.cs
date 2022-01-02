using System;
using System.Data;

namespace Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IDbTransaction _transaction { get; set; }
        IDbConnection _connection { get; set; }
        IDbCommand CreateCommand(string commandText);
        int Execute(string commandText);
        TResponse QuerySingle<TResponse>(string commandText);
        TResponse QueryList<TResponse>(string commandText);
        object QueryScalar(string commandText);
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}