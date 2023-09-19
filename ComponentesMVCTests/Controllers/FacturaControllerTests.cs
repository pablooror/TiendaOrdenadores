using ComponentesMVC.Controllers;
using ComponentesMVC.Data.Logs;
using ComponentesMVC.Models;
using ComponentesMVC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComponentesMVC.Test
{
    [TestClass]
    public class FacturaControllerTests
    {
        private FakeRepositorioFactura? repositorio;
        private readonly FacturaController controller = new(new FakeRepositorioFactura(), new LoggerManager());
        private Factura? factura;

        [TestInitialize]
        public void TestSetup()
        {
            repositorio = new FakeRepositorioFactura();
            factura = repositorio.ConsultarFactura(1);
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
                Descripcion = "Factura 3",
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
            Assert.IsNotNull(factura);
            var facturaAEditar = controller.Edit(1, factura) as RedirectToActionResult;
            var comprobacion = controller.Index() as ViewResult;

            Assert.IsNotNull(facturaAEditar);
            Assert.IsNotNull(comprobacion);
            Assert.AreEqual("Index", facturaAEditar.ActionName);

            var listaFacturas = comprobacion.ViewData.Model as List<Factura>;
            Assert.IsNotNull(listaFacturas);
            Assert.AreEqual("Factura 1", listaFacturas[0].Descripcion);
            Assert.AreEqual(250, listaFacturas[0].Precio);
        }

        [TestMethod]
        public void ControladorBorrarBien()
        {
            var listaFacturasAntes = controller.Index();
            var result = controller.Delete(1) as ViewResult;
            Assert.IsNotNull(result);
            Assert.AreEqual("Delete", result.ViewName);
            Assert.IsNotNull(result.ViewData.Model);

            var listaFacturasDespues = controller.Index();
            Assert.IsNotNull(listaFacturasDespues);
            Assert.AreNotEqual(listaFacturasAntes, listaFacturasDespues);
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

                var resultFactura = result.ViewData.Model;
                Assert.IsNotNull(resultFactura);
                Assert.IsNotNull(factura);
                Assert.AreEqual(factura.ToString(), resultFactura.ToString());
            }
        }

        [TestMethod]
        public void ControladorIndexBien()
        {
            var result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ViewName);
            Assert.IsNotNull(result.ViewData.Model);

            var listaFacturas = result.ViewData.Model as List<Factura>;
            Assert.IsNotNull(listaFacturas);
            Assert.AreEqual(1, listaFacturas.Count);
        }
    }
}