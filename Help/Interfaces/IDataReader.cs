using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interfaces
{
    // Fornece um meio de ler um ou mais fluxos diretos de conjuntos de resultados obtidos
    public interface IDataReader : IDataRecord, IDisposable
    {
        int Depth { get; } // Obtém um valor que indica a profundidade de aninhamento para a linha atual.

        bool IsClosed { get; } // Obtém um valor que indica se o leitor de dados está fechado.

        int RecordsAffected { get; } // Obtém o número de linhas alteradas, inseridas ou excluídas pela execução do SQL

        void Close(); // Fecha o objeto System.Data.IDataReader.

        DataTable? GetSchemaTable(); // Retorna um System.Data.DataTable que descreve os metadados da coluna do System.Data.IDataReader.

        bool NextResult(); // Avança o leitor de dados para o próximo resultado, ao ler os resultados

        bool Read(); // Avança System.Data.IDataReader para o próximo registro.
                     // Retorna:
                     // verdadeiro se houver mais linhas; caso contrário, falso.
    }
}