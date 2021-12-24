namespace Enums
{
    public enum CommandType
    {
        Text = 1, // Um comando de texto SQL. (Padrão.)

        StoredProcedure = 4, // O nome de um procedimento armazenado.

        TableDirect = 512 // O nome de uma tabela.
    }
}
