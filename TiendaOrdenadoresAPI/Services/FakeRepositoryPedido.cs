using TiendaOrdenadoresAPI.Models;

namespace TiendaOrdenadoresAPI.Services
{
    public class FakeRepositoryPedido : IRepositorio<Pedido>
    {
        readonly List<Pedido> listaPedidos = new();
        public FakeRepositoryPedido()
        {
            listaPedidos.Add(new Pedido()
            {
                Id = 1,
                Descripcion = "Pedido 1",
                Precio = 284.0,
                FacturaId = 1
            });
        }

        public List<Pedido> ObtenerTodos()
        {
            return listaPedidos;
        }

        public Pedido? Obtener(int Id)
        {
            if (Id < 0 || Id > listaPedidos.Count)
            {
                return null;
            }
            return listaPedidos.First(x => x.Id == Id);
        }

        public void Añadir(Pedido item)
        {
            listaPedidos.Add(item);
        }

        public void Borrar(int id)
        {
            var pedidoABorrar = listaPedidos.First(pedido => pedido.Id == id);
            if (pedidoABorrar != null)
            {
                listaPedidos.Remove(pedidoABorrar);
            }
        }

        public void Actualizar(Pedido pedido)
        {
            var pedidoAEditar = Obtener(pedido.Id);
            if (pedidoAEditar != null)
            {
                pedidoAEditar.Descripcion = pedido.Descripcion;
                pedidoAEditar.Precio = pedido.Precio;
                pedidoAEditar.FacturaId = pedido.FacturaId;
            }
        }

        public int ObtenerUltimoId()
        {
            return 0;
        }
    }
}