using System.Data;
using App.Enums;

namespace App
{
    public class DbSettings
    {
        public DbSettings()
        {
            CommandType = CommandType.Text;
        }

        public string ConnectionString { get; set; }
        public string Commmand { get; set; }
        public EProvider Provider { get; set; }
        public CommandType CommandType { get; set; }
        public ECommandResponseType CommandResponseType { get; set; }
        public int ExecuteNonQueryResponse { get; set; }
        public string ExecuteScalarResponse { get; set; }
        public IDataReader DataReaderResponse { get; set; }

    }
}