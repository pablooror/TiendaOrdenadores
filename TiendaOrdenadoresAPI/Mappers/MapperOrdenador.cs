using Microsoft.Data.SqlClient;
using TiendaOrdenadoresAPI.Models;

namespace TiendaOrdenadoresAPI.Mappers
{
    public class MapperOrdenador : IMapper<Ordenador>
    {
        public Ordenador Map(SqlDataReader dataReader)
        {
            return new Ordenador()
            {
                Id = Convert.ToInt32(dataReader["Id"]),
                Descripcion = Convert.ToString(dataReader["Descripcion"]),
                Precio = Convert.ToDouble(dataReader["Precio"]),
                PedidoId = Convert.ToInt32(dataReader["PedidoId"])
            };
        }
    }
}
