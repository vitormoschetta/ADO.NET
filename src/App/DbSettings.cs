using System.Data;
using App.Enums;

namespace App
{
    public class DbSettings 
    {
        public string ConnectionString { get; set; }
        public string Comando { get; set; }
        public EProvider Provider { get; set; }
        public CommandType CommandType { get; set; }
        public EReturnCommamndType ReturnCommamndType { get; set; }
        public string RespostaTexto { get; set; }
        public int RespostaInteiro { get; set; }
        public IDataReader RespostaDataReader { get; set; }


        public DbSettings GetSqlServerDbSettings()
        {
            return new DbSettings()
            {            
                ConnectionString = "Server=localhost;Database=master;User=sa;Password=Pass123*;",
                Comando = "SELECT @@version",
                Provider = EProvider.SqlServer,
                CommandType = CommandType.Text,
                ReturnCommamndType = EReturnCommamndType.ExecuteScalar            
            };
        }

        public DbSettings GetPostgresDbSettings()
        {
            return new DbSettings()
            {            
                ConnectionString = "Server=localhost;Database=master;User=sa;Password=Pass123*;",
                Comando = "SELECT @@version",
                Provider = EProvider.Postgresql,
                CommandType = CommandType.Text,
                ReturnCommamndType = EReturnCommamndType.ExecuteScalar            
            };
        }

        public DbSettings GetOracleDbSettings()
        {
            return new DbSettings()
            {            
                ConnectionString = "Server=localhost;Database=master;User=sa;Password=Pass123*;",
                Comando = "SELECT @@version",
                Provider = EProvider.Oracle,
                CommandType = CommandType.Text,
                ReturnCommamndType = EReturnCommamndType.ExecuteScalar            
            };
        }

    }
}