namespace Interfaces
{
    // Representa uma instrução SQL que é executada enquanto conectada a uma fonte de dados
    public interface IDbCommand : IDisposable
    {
        string CommandText { get; set; } // Obtém ou define o comando de texto a ser executado na fonte de dados.

        int CommandTimeout { get; set; }

        CommandType CommandType { get; set; } // Indica ou especifica como a propriedade System.Data.IDbCommand.CommandText é interpretado.

        IDbConnection? Connection { get; set; } // Obtém ou define o System.Data.IDbConnection usado por esta instância do System.Data.IDbCommand.

        IDataParameterCollection Parameters { get; } // Os parâmetros da instrução SQL ou procedimento armazenado.

        IDbTransaction? Transaction { get; set; } // Obtém ou define a transação na qual o objeto Command é executado.

        // Obtém ou define como os resultados do comando são aplicados ao System.Data.DataRow quando
        // usado pelo método System.Data.IDataAdapter.Update (System.Data.DataSet) de um
        // System.Data.Common.DbDataAdapter.
        UpdateRowSource UpdatedRowSource { get; set; }

        void Cancel(); // Tenta cancelar a execução de um System.Data.IDbCommand.

        IDbDataParameter CreateParameter(); // Cria uma nova instância de um objeto System.Data.IDbDataParameter.

        // Executa uma instrução SQL contra o objeto Connection e retorna o número de linhas afetadas ( INSERT, DELETE e UPDATE)
        int ExecuteNonQuery(); 

        // Executa o System.Data.IDbCommand.CommandText contra o System.Data.IDbCommand.Connection
        // e retorna um System.Data.IDataReader (SELECT)
        IDataReader ExecuteReader();

        IDataReader ExecuteReader(CommandBehavior behavior);
                
        object? ExecuteScalar(); // Executa a consulta e retorna um único valor.(uma linha e uma coluna)
        
        void Prepare(); // Cria uma versão preparada (ou compilada) do comando na fonte de dados.
    }
}