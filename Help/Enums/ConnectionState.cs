namespace Enums
{
    [Flags]
    public enum ConnectionState
    {
        Closed = 0, //     The connection is closed.
        Open = 1, // The connection is open.
        Connecting = 2, // O objeto de conexão está se conectando à fonte de dados.
        Executing = 4, // O objeto de conexão está executando um comando.
        Fetching = 8, // O objeto de conexão está recuperando dados.
        Broken = 16 // A conexão com a fonte de dados foi interrompida. 
    }
}
