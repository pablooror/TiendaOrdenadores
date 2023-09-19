using ComponentesMVC.Models;

namespace ComponentesMVC.Services
{
    public interface IRepositorioFactura
    {
        Factura ConsultarFactura(int Id);
        void AgregarFactura(Factura factura);
        void EditarFactura(Factura factura);
        void BorrarFactura(int Id);
        List<Factura> ListarFacturas();
        List<Pedido> ListarPedidosEnFactura(Factura factura);
    }
}
