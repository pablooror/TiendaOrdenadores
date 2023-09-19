using ComponentesMVC.Controllers;
using ComponentesMVC.Data.Logs;
using ComponentesMVC.Models;
using ComponentesMVC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComponentesMVC.Test
{
    [TestClass]
    public class OrdenadorControllerTests
    {
        private FakeRepositorioOrdenador? repositorio;
        private readonly OrdenadorController controller = new(new FakeRepositorioOrdenador(), new LoggerManager());
        private Ordenador? ordenador;
        private Ordenador? nuevoPc; 

        [TestInitialize]
        public void TestSetup()
        {
            repositorio = new FakeRepositorioOrdenador();
            ordenador = repositorio.ConsultarOrdenador(1);
            nuevoPc = new()
            {
                Descripcion = "Ordenador 2",
                Precio = 250,
                PedidoId = 2
            };
        }

        [TestMethod]
        public void ViewCreateBien()
        {
            var result = controller.Create() as ViewResult;
            Assert.IsNotNull(result);
            Assert.AreEqual("Create", result.ViewName);
        }

        [TestMethod]
        public void ContoladorCrear()
        {
            var result = controller.Create(new()
            {
                Descripcion = "Ordenador 3",
                Precio = 500
            });

            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            var redirect = result as RedirectToActionResult;
            Assert.IsNotNull(redirect);
            Assert.AreEqual("Index", redirect.ActionName);
        }

        [TestMethod]
        public void ViewEdit()
        {
            var result = controller.Edit(1) as ViewResult;
            Assert.IsNotNull(result);
            Assert.AreEqual("Edit", result.ViewName);
        }

        [TestMethod]
        public void ControladorEdit()
        {
            Assert.IsNotNull(nuevoPc);
            var compAEditar = controller.Edit(1, nuevoPc) as RedirectToActionResult;
            var comprobacion = controller.Index() as ViewResult;

            Assert.IsNotNull(compAEditar);
            Assert.IsNotNull(comprobacion);
            Assert.AreEqual("Index", compAEditar.ActionName);

            var listaComp = comprobacion.ViewData.Model as List<Ordenador>;
            Assert.IsNotNull(listaComp);
            Assert.AreEqual("Ordenador 2", listaComp[0].Descripcion);
            Assert.AreEqual(250, listaComp[0].Precio);
        }

        [TestMethod]
        public void ControladorBorrarBien()
        {
            var listaPcAntes = controller.Index();
            var result = controller.Delete(1) as ViewResult;
            Assert.IsNotNull(result);
            Assert.AreEqual("Delete", result.ViewName);
            Assert.IsNotNull(result.ViewData.Model);

            var listaPcDespues = controller.Index();
            Assert.IsNotNull(listaPcDespues);
            Assert.AreNotEqual(listaPcAntes, listaPcDespues);
        }

        [TestMethod]
        public void ControladorBorrarConfirmed()
        {

            var result = controller.DeleteConfirmed(0) as RedirectToActionResult;
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ActionName);
        }

        [TestMethod]
        public void ControladorDetallesBien()
        {
            if (repositorio != null)
            {
                var result = controller.Details(1) as ViewResult;
                Assert.IsNotNull(result);
                Assert.AreEqual("Details", result.ViewName);

                var resultPc = result.ViewData.Model;
                Assert.IsNotNull(resultPc);
                Assert.IsNotNull(ordenador);
                Assert.AreEqual(ordenador.ToString(), resultPc.ToString());
            }
        }

        [TestMethod]
        public void ControladorIndexBien()
        {
            var result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ViewName);
            Assert.IsNotNull(result.ViewData.Model);

            var listaPc = result.ViewData.Model as List<Ordenador>;
            Assert.IsNotNull(listaPc);
            Assert.AreEqual(1, listaPc.Count);
        }
    }
}