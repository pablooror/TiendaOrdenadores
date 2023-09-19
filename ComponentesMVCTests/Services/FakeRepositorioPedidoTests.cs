using ComponentesMVC.Controllers;
using ComponentesMVC.Models;
using ComponentesMVC.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComponentesMVCTests.Services
{
    [TestClass()]
    public class FakeRepositorioPedidoTests
    {
        private FakeRepositorioPedido? fakeRepository;
        private Pedido? pedido;

        [TestInitialize]
        public void Init()
        {
            fakeRepository = new FakeRepositorioPedido();
            pedido = fakeRepository.ConsultarPedido(1);

            fakeRepository.AgregarPedido(pedido);
            Assert.IsNotNull(pedido);
        }

        [TestMethod()]
        public void AgregarPEdido()
        {
            if (fakeRepository != null) 
            {
                Pedido nuevoPedido = new()
                {
                    Descripcion = "Portatil Asus 1",
                    Precio = 350
                };
                fakeRepository.AgregarPedido(nuevoPedido);

                Assert.IsNotNull(nuevoPedido);
                Assert.AreEqual(350, nuevoPedido.Precio);
                Assert.AreEqual(3, fakeRepository.ListarPedidos().Count);
            }
        }

        [TestMethod()]
        public void BorrarPedido()
        {
            if (fakeRepository != null)
            {
                fakeRepository.BorrarPedido(1);
                Assert.AreEqual(1, fakeRepository.ListarPedidos().Count);
            }
        }

        [TestMethod()]
        public void ListarPedidos()
        {
            if (fakeRepository != null)
            {
                List<Pedido> listaPedidos = fakeRepository.ListarPedidos();
                Assert.IsNotNull(listaPedidos);
                Assert.AreEqual(2, listaPedidos.Count);
            }
        }

        [TestMethod()]
        public void ConsultarPedidos()
        {
            if (fakeRepository != null)
            {
                Pedido pedidoConsultado = fakeRepository.ConsultarPedido(1);
                Assert.AreEqual(1, pedidoConsultado.Id);
                Assert.AreEqual("Pedido 1", pedidoConsultado.Descripcion);
                Assert.AreEqual(250, pedidoConsultado.Precio);
                Assert.AreEqual(1, pedidoConsultado.FacturaId);
            }
        }

        [TestMethod()]
        public void EditarPedido()
        {
            if (fakeRepository != null)
            {
                var pedidoAEditar = fakeRepository.ConsultarPedido(1);
                fakeRepository.EditarPedido(pedidoAEditar);

                Assert.IsNotNull(pedidoAEditar);
                Assert.AreEqual(1, pedidoAEditar.Id);
                Assert.AreEqual("Pedido 1", pedidoAEditar.Descripcion);
                Assert.AreEqual(250, pedidoAEditar.Precio);
                Assert.AreEqual(1, pedidoAEditar.FacturaId);
            }
        }

        [TestMethod]
        public void ListarPcEnPedido()
        {
            if (fakeRepository != null)
            {
                List<Ordenador> listaPc = fakeRepository.ListarPcEnPedido(pedido);
                Assert.IsNotNull(listaPc);
                Assert.AreEqual(1, listaPc.Count);
            }
        }
    }
}