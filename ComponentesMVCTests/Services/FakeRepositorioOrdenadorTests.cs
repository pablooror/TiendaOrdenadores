using ComponentesMVC.Controllers;
using ComponentesMVC.Models;
using ComponentesMVC.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComponentesMVCTests.Services
{
    [TestClass()]
    public class FakeRepositorioOrdenadorTests
    {
        private FakeRepositorioOrdenador? fakeRepository;
        private Ordenador? ordenador;

        [TestInitialize]
        public void Init()
        {
            fakeRepository = new FakeRepositorioOrdenador();
            ordenador = fakeRepository.ConsultarOrdenador(1);

            fakeRepository.AgregarOrdenador(ordenador);
            Assert.IsNotNull(ordenador);
        }

        [TestMethod()]
        public void AgregarOrdenador()
        {
            if (fakeRepository != null) 
            {
                Ordenador nuevoPc = new()
                {
                    Descripcion = "Portatil Asus 1",
                    Precio = 350
                };
                fakeRepository.AgregarOrdenador(nuevoPc);

                Assert.IsNotNull(nuevoPc);
                Assert.AreEqual(350, nuevoPc.Precio);
                Assert.AreEqual(3, fakeRepository.ListarOrdenadores().Count);
            }
        }

        [TestMethod()]
        public void BorrarOrdenador()
        {
            if (fakeRepository != null)
            {
                fakeRepository.BorrarOrdenador(1);
                Assert.AreEqual(1, fakeRepository.ListarOrdenadores().Count);
            }
        }

        [TestMethod()]
        public void ListarOrdenador()
        {
            if (fakeRepository != null)
            {
                List<Ordenador> listaOrdenadores = fakeRepository.ListarOrdenadores();
                Assert.IsNotNull(listaOrdenadores);
                Assert.AreEqual(2, listaOrdenadores.Count);
            }
        }

        [TestMethod()]
        public void ConsultarOrdenador()
        {
            if (fakeRepository != null)
            {
                Ordenador pcConsultado = fakeRepository.ConsultarOrdenador(1);
                Assert.AreEqual(1, pcConsultado.Id);
                Assert.AreEqual("Ordenador 1", pcConsultado.Descripcion);
                Assert.AreEqual(250, pcConsultado.Precio);
                Assert.AreEqual(1, pcConsultado.PedidoId);
            }
        }

        [TestMethod()]
        public void EditarOrdenador()
        {
            if (fakeRepository != null)
            {
                var pcAEditar = fakeRepository.ConsultarOrdenador(1);
                fakeRepository.EditarOrdenador(pcAEditar);

                Assert.IsNotNull(pcAEditar);
                Assert.AreEqual(1, pcAEditar.Id);
                Assert.AreEqual("Ordenador 1", pcAEditar.Descripcion);
                Assert.AreEqual(250, pcAEditar.Precio);
                Assert.AreEqual(1, pcAEditar.PedidoId);
            }
        }

        [TestMethod]
        public void ListarCompDelPc()
        {
            if (fakeRepository != null)
            {
                List<Componente> listaComp = fakeRepository.ListarCompDelPc(ordenador);

                Assert.IsNotNull(listaComp);
                Assert.AreEqual(1, listaComp.Count);
            }
        }
    }
}