namespace App.Enums
{
    public enum ECommandResponseType
    {
        /// <summary>
        /// Insert, Update and Delete
        /// </summary>
        ExecuteNonQuery = 1,

        /// <summary>
        /// Select single value
        /// </summary>
        ExecuteScalar = 2,

        /// <summary>
        /// Select value set
        /// </summary>
        DataReader = 3
    }
}
