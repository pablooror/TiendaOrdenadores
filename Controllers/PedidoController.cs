using ComponentesMVC.Data.Logs;
using ComponentesMVC.Models;
using ComponentesMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace ComponentesMVC.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IRepositorioPedido _repositorioPedido;
        private readonly ILoggerManager _logger;

        public PedidoController(IRepositorioPedido repositorioPedido, ILoggerManager logger)
        {
            _repositorioPedido = repositorioPedido;
            _logger = logger;
        }

        public ActionResult Index()
        {
            _logger.LogInfo("Se va a mostrar la lista de pedidos");

            return View("Index", _repositorioPedido.ListarPedidos());
        }

        public ViewResult ListaOrdenadores(Pedido pedido)
        {
            _logger.LogInfo("Mostando ordenadores del pedido.");

            return View("ListaOrdenadores", _repositorioPedido.ListarPcEnPedido(pedido));
        }

        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Id,Descripcion, FacturaId")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                _repositorioPedido.AgregarPedido(pedido);
                return RedirectToAction("Index");
            }
            return View("Create", pedido);
        }

        public ActionResult? Edit(int id)
        {
            Pedido? pedido = _repositorioPedido.ConsultarPedido(id);
            if (pedido == null)
            {
                _logger.LogError("No se encuentra el pedido a editar");
                return null;
            }
            return View("Edit", pedido);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("Descripcion, Precio,FacturaId")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                pedido.Id = id;
                _repositorioPedido.EditarPedido(pedido);
                return RedirectToAction("Index");
            }
            return View(pedido);
        }

        public ActionResult Delete(int id)
        {
            var pedidoABorrar = _repositorioPedido.ConsultarPedido(id);

            if (pedidoABorrar == null)
            {
                _logger.LogWarn("Se va a mostrar Delete not found");
                return NotFound();
            }

            return View("Delete", pedidoABorrar);
        }

        // POST: Componentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var pedidoABorrar = _repositorioPedido.ConsultarPedido(id);
            if (pedidoABorrar != null)
            {
                _repositorioPedido.BorrarPedido(id);
            }

            return RedirectToAction(nameof(Index));
        }

        public ActionResult Details(int id)
        {
            var pedido = _repositorioPedido.ConsultarPedido(id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View("Details", pedido);
        }
    }
}