using ComponentesMVC.Models;

namespace ComponentesMVC.Services
{
    public class FakeRepositorioPedido : IRepositorioPedido
    {
        readonly List<Pedido> listaPedidos = new();
        readonly List<Ordenador> listaPc = new();

        public FakeRepositorioPedido()
        {
            listaPedidos.Add(new Pedido()
            {
                Id = 1,
                Descripcion = "Pedido 1",
                Precio = 250,
                FacturaId = 1
            });

            listaPc.Add(new Ordenador()
            {
                Id = 2,
                Descripcion = "Ordenador 2",
                Precio = 300,
                PedidoId = 1
            });
        }
        
        public void AgregarPedido(Pedido pedido)
        {
            listaPedidos.Add(pedido);
        }

        public void BorrarPedido(int Id)
        {
            listaPedidos.RemoveAt(Id);
        }

        public List<Pedido> ListarPedidos()
        {
            return listaPedidos;
        }

        public List<Ordenador> ListarPcEnPedido(Pedido pedido)
        {
            return listaPc.FindAll(o => o.PedidoId == pedido.Id);
        }

        public Pedido Pedido(int Id)
        {
            return listaPedidos.First(x => x.Id == Id);
        }

        public void EditarPedido(Pedido pedido)
        {
            var pedidoAEditar = ConsultarPedido(pedido.Id);
            if (pedidoAEditar != null)
            {
                pedidoAEditar.Descripcion = pedido.Descripcion;
                pedidoAEditar.Precio = pedido.Precio;
                pedidoAEditar.FacturaId = pedido.FacturaId;
            }
        }

        public Pedido ConsultarPedido(int Id)
        {
            var pedidoBuscado = listaPedidos.Find(p => p.Id == Id);
            return pedidoBuscado;
        }
    }
}
