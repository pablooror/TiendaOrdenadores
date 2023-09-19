using TiendaOrdenadoresAPI.Models;

namespace TiendaOrdenadoresAPI.Services.Consultas
{
    public class ConsultasFactura : IConsultas<Factura>
    {
        public string Agregar(Factura factura)
        {
            return "INSERT INTO Facturas (Descripcion, Precio)" +
                   "VALUES" +
                   $"('{factura.Descripcion}', '{factura.Precio}')";
        }

        public string Borrar(int id)
        {
            return $"DELETE FROM Facturas WHERE Id = {id}";
        }

        public string Consultar(int id)
        {
            return $"SELECT * FROM Facturas WHERE Id = {id}";
        }

        public string Editar(Factura factura)
        {
            return "UPDATE Facturas SET " +
                   $"Descripcion = '{factura.Descripcion}'," +
                   $"Precio = '{factura.Precio}'," +
                   $"WHERE Id = {factura.Id}";
        }

        public string ListarTodos()
        {
            return $"SELECT * FROM Facturas";
        }

        public string ObtenerUltimoId()
        {
            return "SELECT MAX(Id) AS Id FROM Facturas";
        }

        public string ComponentesDelPedido(Factura? factura)
        {
            return $"SELECT * FROM Pedidos WHERE FacturaId = {factura.Id}";
        }
    }
}
