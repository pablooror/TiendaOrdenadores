using ComponentesMVC.Data.Logs;
using ComponentesMVC.Models;

namespace ComponentesMVC.Services
{
    public class EFRepositorioPedido : IRepositorioPedido
    {
        private readonly TiendaOrdenadoresContext? _context;
        private readonly ILoggerManager _logger;
        public EFRepositorioPedido(ILoggerManager logger, TiendaOrdenadoresContext context)
        {
            this._logger = logger;
            this._logger.LogInfo("Logger");
            this._context = context;
        }

        public void AgregarPedido(Pedido pedido)
        {
            if (_context != null)
            {
                double? precio = _context.Ordenadores.Where(o => o.PedidoId == pedido.Id).Sum(o => o.Precio);
                pedido.Precio = precio;

                _context.Pedidos.Add(pedido);
                _logger.LogInfo($"Pedido nº {pedido.Id} añadido");

                Factura? factura = _context.Facturas.FirstOrDefault(f => f.Id == pedido.FacturaId);
                if (factura != null) factura.Precio += pedido.Precio;
                _context.SaveChanges();
            }
        }

        public void BorrarPedido(int Id)
        {
            var pedidoABorrar = ConsultarPedido(Id);
            if (_context != null)
            {
                _context.Pedidos.Remove(pedidoABorrar);
                _context.SaveChanges();
            }
        }

        public Pedido ConsultarPedido(int Id)
        {
            if (_context != null)
            {
                var pedidoBuscado = _context.Pedidos.Find(Id);
                if (pedidoBuscado != null) return pedidoBuscado;
            }
            return null;
        }

        public void EditarPedido(Pedido pedido)
        {
            var pedidoAEditar = ConsultarPedido(pedido.Id);
            if (_context != null)
            {
                pedidoAEditar.Descripcion = pedido.Descripcion;
                pedidoAEditar.FacturaId = pedido.FacturaId;
                double? precio = _context.Ordenadores.Where(o => o.PedidoId == pedidoAEditar.Id).Sum(o => o.Precio);
                pedidoAEditar.Precio = precio;

                _logger.LogInfo($"Pedido nº {pedidoAEditar.Id} editado");

                Factura? factura = _context.Facturas.FirstOrDefault(f => f.Id == pedido.FacturaId);
                if (factura != null) factura.Precio += pedido.Precio;
                _context.SaveChanges();
            }
        }

        public List<Ordenador> ListarPcEnPedido(Pedido pedido)
        {
            if (_context != null)
            {
                return _context.Ordenadores.Where(o => o.PedidoId == pedido.Id).ToList();
            }
            return null;
        }

        public List<Pedido> ListarPedidos()
        {
            if (_context != null)
            {
                foreach (var pedido in _context.Pedidos.ToList())
                {
                    pedido.Precio = _context.Ordenadores.Where(o => o.PedidoId == pedido.Id).Sum(o => o.Precio);
                    _context.SaveChanges();
                }
                return _context.Pedidos.ToList();
            }
            return null;
        }
    }
}
