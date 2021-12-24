namespace Interfaces
{
    // Representa uma transação a ser realizada em uma fonte de dados e é implementada
    // por provedores de dados .NET Framework que acessam bancos de dados relacionais.
    public interface IDbTransaction : IDisposable
    {
        IDbConnection? Connection { get; } // Especifica o objeto Connection para associar à transação.
        
        IsolationLevel IsolationLevel { get; }
        
        void Commit(); // Confirma a transação do banco de dados.
               
        void Rollback(); // Reverte uma transação de um estado pendente.
    }
}