using ComponentesMVC.Data.Logs;
using ComponentesMVC.Models;

namespace ComponentesMVC.Services
{
    public class EFRepositorioFactura : IRepositorioFactura
    {
        private readonly TiendaOrdenadoresContext? _context;
        private readonly ILoggerManager _logger;
        public EFRepositorioFactura(ILoggerManager logger, TiendaOrdenadoresContext context)
        {
            this._logger = logger;
            this._logger.LogInfo("Logger");
            this._context = context;
        }

        public void AgregarFactura(Factura factura)
        {
            if (_context != null)
            {
                double? precio = _context.Pedidos.Where(p => p.FacturaId == factura.Id).Sum(p => p.Precio);
                factura.Precio = precio;
                _context.Facturas.Add(factura);
                _logger.LogInfo($"Factura nº {factura.Id} añadida");
                _context.SaveChanges();
            }
        }

        public void BorrarFactura(int Id)
        {
            var facturaABorrar = ConsultarFactura(Id);
            if (_context != null)
            {
                _context.Facturas.Remove(facturaABorrar);
                _context.SaveChanges();
            }
        }

        public Factura ConsultarFactura(int Id)
        {
            if (_context != null)
            {
                var facturaBuscada = _context.Facturas.Find(Id);
                if (facturaBuscada != null) return facturaBuscada;
            }
            return null;
        }

        public void EditarFactura(Factura factura)
        {
            var facturaAEditar = ConsultarFactura(factura.Id);
            if (_context != null)
            {
                facturaAEditar.Descripcion = factura.Descripcion;
                double? precio = _context.Pedidos.Where(p => p.FacturaId == facturaAEditar.Id).Sum(f => f.Precio);
                facturaAEditar.Precio = precio;

                _logger.LogInfo($"Factura nº {facturaAEditar.Id} editada");
                _context.SaveChanges();
            }
        }

        public List<Factura> ListarFacturas()
        {
            if (_context != null)
            {
                foreach (var factura in _context.Facturas.ToList())
                {
                    factura.Precio = _context.Pedidos.Where(p => p.FacturaId == factura.Id).Sum(f => f.Precio);
                    _context.SaveChanges();
                }

                return _context.Facturas.ToList();
            }
            return null;
        }

        public List<Pedido> ListarPedidosEnFactura(Factura factura)
        {
            if (_context != null)
            {
                return _context.Pedidos.Where(p => p.FacturaId == factura.Id).ToList();
            }
            return null;
        }
    }
}
