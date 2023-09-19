using Microsoft.Data.SqlClient;
using TiendaOrdenadoresAPI.Models;

namespace TiendaOrdenadoresAPI.Mappers
{
    public class MapperFactura : IMapper<Factura>
    {
        public Factura Map(SqlDataReader dataReader)
        {
            return new Factura()
            {
                Id = Convert.ToInt32(dataReader["Id"]),
                Descripcion = Convert.ToString(dataReader["Descripcion"]),
                Precio = Convert.ToDouble(dataReader["Precio"]),
            };
        }
    }
}
