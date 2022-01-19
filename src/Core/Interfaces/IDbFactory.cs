using System.Data;
using Core.Enums;

namespace Core.Interfaces
{
    public interface IDbFactory
    {
        string ConnectionString { get; set; }
        EDataBaseProvider EDataBaseProvider { get; set; }

        IDbConnection CreateConector(EDataBaseProvider dataBaseProvider);
    }
}