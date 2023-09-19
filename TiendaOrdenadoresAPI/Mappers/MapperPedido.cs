using Microsoft.Data.SqlClient;
using TiendaOrdenadoresAPI.Models;

namespace TiendaOrdenadoresAPI.Mappers
{
    public class MapperPedido : IMapper<Pedido>
    {
        public Pedido Map(SqlDataReader dataReader)
        {
            return new Pedido()
            {
                Id = Convert.ToInt32(dataReader["Id"]),
                Descripcion = Convert.ToString(dataReader["Descripcion"]),
                Precio = Convert.ToDouble(dataReader["Precio"]),
                FacturaId = Convert.ToInt32(dataReader["FacturaId"])
            };
        }
    }
}
