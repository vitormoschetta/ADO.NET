using Core.Enums;

namespace Core
{
    /// <summary>
    /// Configurações de conexão com o Banco de Dados
    /// </summary>
    public class DbConnectionSettings
    {
        public DbConnectionSettings(string connectionString, EDataBaseProvider dataBaseProvider)
        {
            ConnectionString = connectionString;
            DataBaseProvider = dataBaseProvider;
        }

        public DbConnectionSettings()
        {
            
        }

        /// <summary>
        /// String de Conexão Completa
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// Enum Provedor de Banco de Dados: SqlServer, Postgres, Oracle, etc
        /// </summary>
        public EDataBaseProvider DataBaseProvider { get; set; }
    }
}