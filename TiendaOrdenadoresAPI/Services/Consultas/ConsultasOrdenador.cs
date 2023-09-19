using TiendaOrdenadoresAPI.Models;

namespace TiendaOrdenadoresAPI.Services.Consultas
{
    public class ConsultasOrdenador : IConsultas<Ordenador>
    {
        public string Agregar(Ordenador pc)
        {
            return "INSERT INTO Ordenadores (Descripcion, Precio, PedidoId)" +
                   "VALUES" +
                   $"('{pc.Descripcion}', '{pc.Precio}', '{pc.PedidoId}')";
        }

        public string Borrar(int id)
        {
            return $"DELETE FROM Ordenadores WHERE Id = {id}";
        }

        public string Consultar(int id)
        {
            return $"SELECT * FROM Ordenadores WHERE Id = {id}";
        }

        public string Editar(Ordenador pc)
        {
            return "UPDATE Ordenadores SET " +
                   $"Descripcion = '{pc.Descripcion}'," +
                   $"Precio = '{pc.Precio}'," +
                   $"PedidoId = '{pc.PedidoId}'" +
                   $"WHERE Id = '{pc.Id}'";
        }

        public string ListarTodos()
        {
            return $"SELECT * FROM Ordenadores";
        }

        public string ObtenerUltimoId()
        {
            return "SELECT MAX(Id) AS Id FROM Ordenadores";
        }

        public string ComponentesDelPc(Ordenador? pc)
        {
            return $"SELECT * FROM Componentes WHERE OrdenadorId = {pc.Id}";
        }
    }
}
