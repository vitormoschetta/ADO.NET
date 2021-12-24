using System.Data;

namespace App
{
    public class Conexao
    {
        IDbConnection _dbConnection;
        public Conexao(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        private void Conectar()
        {
            if (_dbConnection.State == ConnectionState.Closed)
                _dbConnection.Open();                
                
        }

        private void Desconectar()
        {
            if (_dbConnection.State == ConnectionState.Open)
                _dbConnection.Close();
        }

        public string ExecuteScalar(IDbCommand command)
        {
            Conectar();
            string resultado = (string)command.ExecuteScalar();
            Desconectar();
            return resultado;
        }

        public IDataReader ExecuteReader(IDbCommand command)
        {
            Conectar();
            IDataReader reader = command.ExecuteReader();
            Desconectar();
            return reader;
        }

        public int ExecuteNonQuery(IDbCommand command)
        {
            Conectar();
            int reader = command.ExecuteNonQuery();
            Desconectar();
            return reader;
        }
    }
}