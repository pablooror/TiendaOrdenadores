using ComponentesMVC.Controllers;
using ComponentesMVC.Data.Logs;
using ComponentesMVC.Models;
using ComponentesMVC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComponentesMVC.Test
{
    [TestClass]
    public class ComponenteControllerTests
    {
        private FakeRepositorioComponente? repositorio;
        private readonly ComponenteController controller = new(new FakeRepositorioComponente(), new LoggerManager());
        private Componente? componente;
        private Componente? nuevoComp; 

        [TestInitialize]
        public void TestSetup()
        {
            repositorio = new FakeRepositorioComponente();
            componente = repositorio.ConsultarComponente(1);
            nuevoComp = new()
            {
                Descripcion = "Memoria RAM Kingston 16 GB",
                NumSerie = "K16GBYUT",
                Gigas = 16,
                Cores = 0,
                Tipo = 0,
                Calor = 18,
                Precio = 39
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
                Descripcion = "Disco Duro San Disk 1TB",
                NumSerie = "SD1024RDE",
                Tipo = EnumComponente.Disco,
                Gigas = 1024,
                Cores = 0,
                Calor = 16,
                Precio = 44
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
            Assert.IsNotNull(nuevoComp);
            var compAEditar = controller.Edit(1, nuevoComp) as RedirectToActionResult;
            var comprobacion = controller.Index() as ViewResult;

            Assert.IsNotNull(compAEditar);
            Assert.IsNotNull(comprobacion);
            Assert.AreEqual("Index", compAEditar.ActionName);

            var listaComp = comprobacion.ViewData.Model as List<Componente>;
            Assert.IsNotNull(listaComp);
            Assert.AreEqual("Memoria RAM Kingston 16 GB", listaComp[0].Descripcion);
            Assert.AreEqual("K16GBYUT", listaComp[0].NumSerie);
            Assert.AreEqual(EnumComponente.Memoria, listaComp[0].Tipo);
            Assert.AreEqual(16, listaComp[0].Gigas);
            Assert.AreEqual(0, listaComp[0].Cores);
            Assert.AreEqual(18, listaComp[0].Calor);
            Assert.AreEqual(39, listaComp[0].Precio);
        }

        [TestMethod]
        public void ControladorBorrarBien()
        {
            var listaCompAntes = controller.Index();
            var result = controller.Delete(1) as ViewResult;
            Assert.IsNotNull(result);
            Assert.AreEqual("Delete", result.ViewName);
            Assert.IsNotNull(result.ViewData.Model);

            var listaCompDespues = controller.Index();
            Assert.IsNotNull(listaCompDespues);
            Assert.AreNotEqual(listaCompAntes, listaCompDespues);
        }

        [TestMethod]
        [ExpectedException(typeof(System.InvalidOperationException))]
        public void ControladorBorrarNulo()
        {
            var result = controller.Delete(4) as ViewResult;
            Assert.IsNull(result);
        }

        [TestMethod]
        [ExpectedException(typeof(System.InvalidOperationException))]
        public void ControladorBorrarConfirmed()
        {

            var resultNulo = controller.DeleteConfirmed(5) as ViewResult;
            Assert.IsNull(resultNulo);

            var result = controller.DeleteConfirmed(1) as RedirectToActionResult;
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

                var resultComponente = result.ViewData.Model;
                Assert.IsNotNull(resultComponente);
                Assert.IsNotNull(componente);
                Assert.AreEqual(componente.ToString(), resultComponente.ToString());
            }
        }

        [TestMethod]
        public void ControladorIndexBien()
        {
            var result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ViewName);
            Assert.IsNotNull(result.ViewData.Model);

            var listaComp = result.ViewData.Model as List<Componente>;
            Assert.IsNotNull(listaComp);
            Assert.AreEqual(1, listaComp.Count);
        }
    }
}