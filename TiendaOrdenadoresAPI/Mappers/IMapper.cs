using Microsoft.Data.SqlClient;

namespace TiendaOrdenadoresAPI.Mappers
{
    public interface IMapper<T>
    {
        T Map(SqlDataReader json);
    }
}
