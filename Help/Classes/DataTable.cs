using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Classes
{
    public class DataTable
    {
        // CONSTRUTORES
        public DataTable(); // Inicializa uma nova instância da classe System.Data.DataTable sem argumentos.
        public DataTable(string? tableName);
        public DataTable(string? tableName, string? tableNamespace);
        protected DataTable(SerializationInfo info, StreamingContext context);


    }
}