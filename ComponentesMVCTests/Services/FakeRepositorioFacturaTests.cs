using ComponentesMVC.Models;
using ComponentesMVC.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComponentesMVCTests.Services
{
    [TestClass()]
    public class FakeRepositorioFacturaTests
    {
        private FakeRepositorioFactura? fakeRepository;
        private Factura? factura;

        [TestInitialize]
        public void Init()
        {
            fakeRepository = new FakeRepositorioFactura();
            factura = fakeRepository.ConsultarFactura(1);

            fakeRepository.AgregarFactura(factura);
            Assert.IsNotNull(factura);
        }

        [TestMethod()]
        public void AgregarFactura()
        {
            if (fakeRepository != null) 
            {
                Factura nuevaFactura = new()
                {
                    Descripcion = "Factura 1",
                    Precio = 350
                };
                fakeRepository.AgregarFactura(nuevaFactura);

                Assert.IsNotNull(nuevaFactura);
                Assert.AreEqual(350, nuevaFactura.Precio);
                Assert.AreEqual(3, fakeRepository.ListarFacturas().Count);
            }
        }

        [TestMethod()]
        public void BorrarFactura()
        {
            if (fakeRepository != null)
            {
                fakeRepository.BorrarFactura(1);
                Assert.AreEqual(1, fakeRepository.ListarFacturas().Count);
            }
        }

        [TestMethod()]
        public void ListarFacturas()
        {
            if (fakeRepository != null)
            {
                List<Factura> listaFacturas = fakeRepository.ListarFacturas();
                Assert.IsNotNull(listaFacturas);
                Assert.AreEqual(2, listaFacturas.Count);
            }
        }

        [TestMethod()]
        public void ConsultarFacturas()
        {
            if (fakeRepository != null)
            {
                Factura facturaConsultada = fakeRepository.ConsultarFactura(1);
                Assert.AreEqual(1, facturaConsultada.Id);
                Assert.AreEqual("Factura 1", facturaConsultada.Descripcion);
                Assert.AreEqual(250, facturaConsultada.Precio);
            }
        }

        [TestMethod()]
        public void EditarFactura()
        {
            if (fakeRepository != null)
            {
                var facturaAEditar = fakeRepository.ConsultarFactura(1);
                fakeRepository.EditarFactura(facturaAEditar);

                Assert.IsNotNull(facturaAEditar);
                Assert.AreEqual(1, facturaAEditar.Id);
                Assert.AreEqual("Factura 1", facturaAEditar.Descripcion);
                Assert.AreEqual(250, facturaAEditar.Precio);
            }
        }

        [TestMethod()]
        public void ListarPedidosEnFactura()
        {
            List<Pedido> listaPedidos = fakeRepository.ListarPedidosEnFactura(factura);

            Assert.IsNotNull(listaPedidos);
            Assert.AreEqual(1, listaPedidos.Count);
        }
    }
}