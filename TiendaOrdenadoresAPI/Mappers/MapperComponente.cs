using Microsoft.Data.SqlClient;
using TiendaOrdenadoresAPI.Models;

namespace TiendaOrdenadoresAPI.Mappers
{
    public class MapperComponente : IMapper<Componente>
    {
        public Componente Map(SqlDataReader dataReader)
        {
            return new Componente()
            {
                Id = Convert.ToInt32(dataReader["Id"]),
                NumSerie = Convert.ToString(dataReader["NumSerie"]) ?? "",
                Descripcion = Convert.ToString(dataReader["Descripcion"]) ?? "",
                Tipo = (EnumComponente)Convert.ToInt32(dataReader["Tipo"]),
                Cores = Convert.ToInt32(dataReader["Cores"]),
                Gigas = Convert.ToDouble(dataReader["Gigas"]),
                Precio = Convert.ToDouble(dataReader["Precio"]),
                Calor = Convert.ToDouble(dataReader["Calor"]),
                OrdenadorId = Convert.ToInt32(dataReader["OrdenadorId"])
            };
        }
    }
}
