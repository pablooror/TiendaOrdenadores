using ComponentesMVC.Models;

namespace ComponentesMVC.Services
{
    public interface IRepositorioPedido
    {
        Pedido ConsultarPedido(int Id);
        void AgregarPedido(Pedido pedido);
        void EditarPedido(Pedido  pedido);
        void BorrarPedido(int Id);
        List<Pedido> ListarPedidos();
        List<Ordenador> ListarPcEnPedido(Pedido pedido);
    }
}
