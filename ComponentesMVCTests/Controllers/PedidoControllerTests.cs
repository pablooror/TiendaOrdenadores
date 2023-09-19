using ComponentesMVC.Controllers;
using ComponentesMVC.Data.Logs;
using ComponentesMVC.Models;
using ComponentesMVC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComponentesMVC.Test
{
    [TestClass]
    public class PedidoControllerTests
    {
        private FakeRepositorioPedido? repositorio;
        private readonly PedidoController controller = new(new FakeRepositorioPedido(), new LoggerManager());
        private Pedido? pedido;
        private Pedido? nuevoPedido; 

        [TestInitialize]
        public void TestSetup()
        {
            repositorio = new FakeRepositorioPedido();
            pedido = repositorio.ConsultarPedido(1);
            nuevoPedido = new()
            {
                Descripcion = "Pedido 2",
                Precio = 250,
                FacturaId = 1
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
                Descripcion = "Pedido 3",
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
            Assert.IsNotNull(nuevoPedido);
            var compAEditar = controller.Edit(1, nuevoPedido) as RedirectToActionResult;
            var comprobacion = controller.Index() as ViewResult;

            Assert.IsNotNull(compAEditar);
            Assert.IsNotNull(comprobacion);
            Assert.AreEqual("Index", compAEditar.ActionName);

            var listaPedidos = comprobacion.ViewData.Model as List<Pedido>;
            Assert.IsNotNull(listaPedidos);
            Assert.AreEqual("Pedido 2", listaPedidos[0].Descripcion);
            Assert.AreEqual(250, listaPedidos[0].Precio);
        }

        [TestMethod]
        public void ControladorBorrarBien()
        {
            var listaPedidosAntes = controller.Index();
            var result = controller.Delete(1) as ViewResult;
            Assert.IsNotNull(result);
            Assert.AreEqual("Delete", result.ViewName);
            Assert.IsNotNull(result.ViewData.Model);

            var listaPedidosDespues = controller.Index();
            Assert.IsNotNull(listaPedidosDespues);
            Assert.AreNotEqual(listaPedidosAntes, listaPedidosDespues);
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

                var resultPedido = result.ViewData.Model;
                Assert.IsNotNull(resultPedido);
                Assert.IsNotNull(pedido);
                Assert.AreEqual(pedido.ToString(), resultPedido.ToString());
            }
        }

        [TestMethod]
        public void ControladorIndexBien()
        {
            var result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ViewName);
            Assert.IsNotNull(result.ViewData.Model);

            var listaPedidos = result.ViewData.Model as List<Pedido>;
            Assert.IsNotNull(listaPedidos);
            Assert.AreEqual(1, listaPedidos.Count);
        }
    }
}