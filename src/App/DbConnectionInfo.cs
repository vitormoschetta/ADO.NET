namespace App
{
    /// <summary>
    /// Informações sobre a conexão com o Banco de Dados
    /// </summary>
    public class DbConnectionInfo
    {
        public DbConnectionInfo(string connectionString, EProvider provider)
        {
            ConnectionString = connectionString;
            Provider = provider;
        }

        public DbConnectionInfo()
        {
            
        }

        /// <summary>
        /// String de Conexão Completa
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// Enum Provedor de Banco de Dados: SqlServer, Postgres, Oracle, etc
        /// </summary>
        public EProvider Provider { get; set; }
    }
}