using ComponentesMVC.Data.Logs;
using ComponentesMVC.Models;
using ComponentesMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace ComponentesMVC.Controllers
{
    public class OrdenadorController : Controller
    {
        private readonly IRepositorioOrdenador _repositorioOrdenador;
        private readonly ILoggerManager _logger;


        public OrdenadorController(IRepositorioOrdenador repositorioOrdenador, ILoggerManager logger)
        {
            _repositorioOrdenador = repositorioOrdenador;
            _logger = logger;
        }

        public ActionResult Index()
        {
            _logger.LogInfo("Se va a mostrar la lista de ordenadores");

            return View("Index", _repositorioOrdenador.ListarOrdenadores());
        }

        public ViewResult ListaComp(Ordenador ordenador)
        {
            _logger.LogInfo("Mostando componentes pertenecientes al ordendor.");

            return View("ListaComp", _repositorioOrdenador.ListarCompDelPc(ordenador));
        }

        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Descripcion, Precio, PedidoId")] Ordenador ordenador)
        {
            if (ModelState.IsValid)
            {
                _repositorioOrdenador.AgregarOrdenador(ordenador);
                return RedirectToAction("Index");
            }
            return View("Create", ordenador);
        }

        public ActionResult? Edit(int id)
        {
            Ordenador? pc = _repositorioOrdenador.ConsultarOrdenador(id);
            if (pc == null)
            {
                _logger.LogError("No se encuentra el ordenador a editar");
                return null;
            }
            return View("Edit", pc);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("Descripcion, Precio, PedidoId")] Ordenador ordenador)
        {
            if (ModelState.IsValid)
            {
                ordenador.Id = id;
                _repositorioOrdenador.EditarOrdenador(ordenador);
                return RedirectToAction("Index");
            }
            return View(ordenador);
        }

        public ActionResult Delete(int id)
        {
            var ordenadorABorrar = _repositorioOrdenador.ConsultarOrdenador(id);

            if (ordenadorABorrar == null)
            {
                _logger.LogWarn("Se va a mostrar Delete not found");
                return NotFound();
            }

            return View("Delete", ordenadorABorrar);
        }

        // POST: Componentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var ordenadorABorrar = _repositorioOrdenador.ConsultarOrdenador(id);
            if (ordenadorABorrar != null)
            {
                _repositorioOrdenador.BorrarOrdenador(id);
            }

            return RedirectToAction(nameof(Index));
        }

        public ActionResult Details(int id)
        {
            var ordenador = _repositorioOrdenador.ConsultarOrdenador(id);
            if (ordenador == null)
            {
                return NotFound();
            }

            return View("Details", ordenador);
        }
    }
}