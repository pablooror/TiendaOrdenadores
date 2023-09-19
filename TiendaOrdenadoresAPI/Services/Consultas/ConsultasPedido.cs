using TiendaOrdenadoresAPI.Models;

namespace TiendaOrdenadoresAPI.Services.Consultas
{
    public class ConsultasPedido : IConsultas<Pedido>
    {
        public string Agregar(Pedido pedido)
        {
            return "INSERT INTO Pedidos (Descripcion, Precio, FacturaId)" +
                   "VALUES" +
                   $"('{pedido.Descripcion}', '{pedido.Precio}', '{pedido.FacturaId}')";
        }

        public string Borrar(int id)
        {
            return $"DELETE FROM Pedidos WHERE Id = {id}";
        }

        public string Consultar(int id)
        {
            return $"SELECT * FROM Pedidos WHERE Id = {id}";
        }

        public string Editar(Pedido pedido)
        {
            return "UPDATE Pedidos SET " +
                   $"Descripcion = '{pedido.Descripcion}'," +
                   $"Precio = '{pedido.Precio}'," +
                   $"PedidoId = '{pedido.FacturaId}'" +
                   $"WHERE Id = {pedido.Id}";
        }

        public string ListarTodos()
        {
            return $"SELECT * FROM Pedidos";
        }

        public string ObtenerUltimoId()
        {
            return "SELECT MAX(Id) AS Id FROM Pedidos";
        }

        public string ComponentesDelPedido(Pedido? pedido)
        {
            return $"SELECT * FROM Ordenadores WHERE PedidoId = {pedido.Id}";
        }
    }
}
