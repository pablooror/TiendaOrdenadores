using ComponentesMVC.Data.Logs;
using ComponentesMVC.Models;
using ComponentesMVC.Services;
using Microsoft.AspNetCore.Mvc;
using ValidatorComponente = ComponentesMVC.Validators.ValidatorComponente;

namespace ComponentesMVC.Controllers
{
    public class ComponenteController : Controller
    {
        private readonly IRepositorioComponente _repositorioComponentes;
        private readonly ILoggerManager _logger;
        private readonly ValidatorComponente _validadorComp;

        public ComponenteController(IRepositorioComponente repositorioComponentes, ILoggerManager logger)
        {
            _repositorioComponentes = repositorioComponentes;
            _logger = logger;
            _validadorComp = new ValidatorComponente(_repositorioComponentes);
        }

        public ActionResult Index()
        {
            _logger.LogInfo("Mostrando lista de componentes");

            return View("Index", _repositorioComponentes.ListarComponentes());
        }

        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Id,Precio,NumSerie,Calor,Cores,Descripcion,Gigas,Tipo, OrdenadorId")] Componente componente)
        {
            if (ModelState.IsValid && _validadorComp.IsValid(componente))
            {
                _repositorioComponentes.AgregarComponente(componente);
                
                return RedirectToAction("Index");
            }
            return View("Create", componente);
        }

        public ActionResult? Edit(int id)
        {
            Componente? compAEditar = _repositorioComponentes.ConsultarComponente(id);
            if (compAEditar == null)
            {
                _logger.LogError("No se encuentra el componente a editar.");
                return null;
            }
            return View("Edit", compAEditar);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("Id,Precio,NumSerie,Calor,Cores,Descripcion,Gigas,Tipo,OrdenadorId")] Componente componente)
        {
            if (ModelState.IsValid)
            {
                componente.Id = id;
                if (_validadorComp.IsValid(componente))
                {
                    _repositorioComponentes.EditarComponente(componente);

                    return RedirectToAction("Index");
                }
            }
            return View(componente);
        }

        public ActionResult Delete(int id)
        {
            var compABorrar = _repositorioComponentes.ConsultarComponente(id);
            if (compABorrar == null)
            {
                _logger.LogWarn("No se encuentra el componente a borrar.");
                return NotFound();
            }
            return View("Delete", compABorrar);
        }

        // POST: Componentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var compABorrar = _repositorioComponentes.ConsultarComponente(id);
            if (compABorrar != null)
            {
                _repositorioComponentes.BorrarComponente(id);
            }
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Details(int id)
        {
            var componente = _repositorioComponentes.ConsultarComponente(id);
            if (componente == null)
            {
                return NotFound();
            }
            return View("Details", componente);
        }
    }
}