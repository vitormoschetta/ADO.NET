namespace Interfaces
{
    // Representa uma conexão aberta com uma fonte de dados e é implementado pelo .NET Framework
    public interface IDbConnection : IDisposable
    {
        string ConnectionString { get; set; }
        int ConnectionTimeout { get; }
        string Database { get; } // nome do banco de dados   
        ConnectionState State { get; } // Enum estado da conexão
        IDbTransaction BeginTransaction(); // Começa uma transação de banco de dados.   
        IDbTransaction BeginTransaction(IsolationLevel il);
        void ChangeDatabase(string databaseName); // altera o banco a ser usado
        void Close(); // Fecha a conexão com o banco de dados.
        IDbCommand CreateCommand(); // Cria e retorna um objeto Command associado à conexão.
        void Open(); // Abre uma conexão de banco de dados com as configurações especificadas por ConnectionString
    }
}