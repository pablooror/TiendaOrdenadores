using ComponentesMVC.Models;

namespace ComponentesMVC.Services
{
    public class FakeRepositorioFactura : IRepositorioFactura
    {
        readonly List<Factura> listaFacturas = new();
        readonly List<Pedido> listaPedidos = new();
        public FakeRepositorioFactura()
        {
            listaFacturas.Add(new Factura()
            {
                Id = 1,
                Descripcion = "Factura 1",
                Precio = 250,
            });

            listaPedidos.Add(new Pedido()
            {
                Id = 2,
                Descripcion = "Pedido 2",
                Precio = 250,
                FacturaId = 1
            });
        }
        
        public void AgregarFactura(Factura factura)
        {
            listaFacturas.Add(factura);
        }

        public void BorrarFactura(int Id)
        {
            listaFacturas.RemoveAt(Id);
        }

        public List<Factura> ListarFacturas()
        {
            return listaFacturas;
        }

        public List<Pedido> ListarPedidosEnFactura(Factura factura)
        {
            return listaPedidos.FindAll(p => p.FacturaId == factura.Id);
        }

        public Factura Factura(int Id)
        {
            return listaFacturas.First(x => x.Id == Id);
        }

        public void EditarFactura(Factura factura)
        {
            var facturaAEditar = ConsultarFactura(factura.Id);
            if (facturaAEditar != null)
            {
                facturaAEditar.Descripcion = factura.Descripcion;
                facturaAEditar.Precio = factura.Precio;
            }
        }

        public Factura ConsultarFactura(int Id)
        {
            var facturaBuscada = listaFacturas.Find(p => p.Id == Id);
            return facturaBuscada;
        }
    }
}
