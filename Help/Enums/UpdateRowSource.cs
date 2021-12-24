namespace Enums
{
    public enum UpdateRowSource
    {
        None = 0, // Quaisquer parâmetros ou linhas retornados são ignorados.
     
        OutputParameters = 1, // Os parâmetros de saída são mapeados para a linha alterada no System.Data.DataSet.
       
        FirstReturnedRecord = 2, // Os dados na primeira linha retornada são mapeados para a linha alterada em System.Data.DataSet.
        
        Both = 3 // Ambos os parâmetros de saída e a primeira linha retornada são mapeados para o alterado
    }
}
