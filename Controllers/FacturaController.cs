using ComponentesMVC.Data.Logs;
using ComponentesMVC.Models;
using ComponentesMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace ComponentesMVC.Controllers
{
    public class FacturaController : Controller
    {
        private readonly IRepositorioFactura _repositorioFactura;
        private readonly ILoggerManager _logger;

        public FacturaController(IRepositorioFactura repositorioFactura, ILoggerManager logger)
        {
            _repositorioFactura = repositorioFactura;
            _logger = logger;
        }

        public ActionResult Index()
        {
            _logger.LogInfo("Se va a mostrar la lista de facturas");

            return View("Index", _repositorioFactura.ListarFacturas());
        }

        public ViewResult ListaPedidos(Factura factura)
        {
            _logger.LogInfo("Mostando pedidos de la factura.");

            return View("ListaPedidos", _repositorioFactura.ListarPedidosEnFactura(factura));
        }

        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Descripcion, Precio")] Factura factura)
        {
            if (ModelState.IsValid)
            {
                _repositorioFactura.AgregarFactura(factura);
                return RedirectToAction("Index");
            }
            return View("Create", factura);
        }

        public ActionResult? Edit(int id)
        {
            Factura? factura = _repositorioFactura.ConsultarFactura(id);
            if (factura == null)
            {
                _logger.LogError("No se encuentra la factura a editar");
                return null;
            }
            return View("Edit", factura);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("Descripcion, Precio")] Factura factura)
        {
            if (ModelState.IsValid)
            {
                factura.Id = id;
                _repositorioFactura.EditarFactura(factura);
                return RedirectToAction("Index");
            }
            return View(factura);
        }

        public ActionResult Delete(int id)
        {
            var facturaABorrar = _repositorioFactura.ConsultarFactura(id);

            if (facturaABorrar == null)
            {
                _logger.LogWarn("Se va a mostrar Delete not found");
                return NotFound();
            }

            return View("Delete", facturaABorrar);
        }

        // POST: Componentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var pedidoABorrar = _repositorioFactura.ConsultarFactura(id);
            if (pedidoABorrar != null)
            {
                _repositorioFactura.BorrarFactura(id);
            }

            return RedirectToAction(nameof(Index));
        }

        public ActionResult Details(int id)
        {
            var factura = _repositorioFactura.ConsultarFactura(id);
            if (factura == null)
            {
                return NotFound();
            }

            return View("Details", factura);
        }
    }
}