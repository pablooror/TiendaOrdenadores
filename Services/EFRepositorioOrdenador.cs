using ComponentesMVC.Data.Logs;
using ComponentesMVC.Models;

namespace ComponentesMVC.Services
{
    public class EFRepositorioOrdenador : IRepositorioOrdenador
    {
        private readonly TiendaOrdenadoresContext? _context;
        private readonly ILoggerManager _logger;
        public EFRepositorioOrdenador(ILoggerManager logger, TiendaOrdenadoresContext context)
        {
            this._logger = logger;
            this._logger.LogInfo("Logger");
            this._context = context;
        }

        public void AgregarOrdenador(Ordenador ordenador)
        {
            if (_context != null)
            {
                double precio = _context.Componentes.Where(c => c.OrdenadorId == ordenador.Id).Sum(c => c.Precio);
                ordenador.Precio = precio;
                _context.Ordenadores.Add(ordenador);

                Pedido? pedido = _context.Pedidos.FirstOrDefault(p => p.Id == ordenador.PedidoId);
                if (pedido != null) pedido.Precio += ordenador.Precio;
                _logger.LogInfo($"Ordenador nº {ordenador.Id} añadido");
                _context.SaveChanges();
            }
        }

        public void BorrarOrdenador(int Id)
        {
            Ordenador? ordenadorABorrar = ConsultarOrdenador(Id);
            if (_context != null && ordenadorABorrar != null)
            {
                _context.Ordenadores.Remove(ordenadorABorrar);
                _context.SaveChanges();
            }
        }

        public Ordenador? ConsultarOrdenador(int Id)
        {
            if (_context != null)
            {
                var ordenadorBuscado = _context.Ordenadores.Find(Id);
                if (ordenadorBuscado != null) return ordenadorBuscado;
            }

            return null;
        }

        public void EditarOrdenador(Ordenador ordenador)
        {
            Ordenador? ordenadorAEditar = ConsultarOrdenador(ordenador.Id);
            if (_context != null && ordenadorAEditar != null)
            {
                ordenadorAEditar.Descripcion = ordenador.Descripcion;
                ordenadorAEditar.PedidoId = ordenador.PedidoId;
                double precio = _context.Componentes.Where(c => c.OrdenadorId == ordenadorAEditar.Id).Sum(c => c.Precio);
                ordenadorAEditar.Precio = precio;

                _logger.LogInfo($"Ordenador nº {ordenadorAEditar.Id} editado");

                Pedido? pedido = _context.Pedidos.FirstOrDefault(p => p.Id == ordenador.PedidoId);
                if (pedido != null) pedido.Precio += ordenador.Precio;
                _context.SaveChanges();
            }
        }

        public List<Componente>? ListarCompDelPc(Ordenador ordenador)
        {
            if (_context != null)
            {
                return _context.Componentes.Where(c => c.OrdenadorId == ordenador.Id).ToList();
            }
            return null;
        }

        public List<Ordenador>? ListarOrdenadores()
        {
            if (_context != null)
            {
                foreach (Ordenador ordenador in _context.Ordenadores.ToList())
                {
                    ordenador.Precio = _context.Componentes.Where(c => c.OrdenadorId == ordenador.Id).Sum(c => c.Precio);
                    _context.SaveChanges();
                }

                return _context.Ordenadores.ToList();
            }
            return null;
        }
    }
}
