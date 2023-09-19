using ComponentesMVC.Controllers;
using ComponentesMVC.Models;
using ComponentesMVC.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComponentesMVCTests.Services
{
    [TestClass()]
    public class FakeRepositorioComponenteTests
    {
        private FakeRepositorioComponente? fakeRepository;
        private Componente? componente;

        [TestInitialize]
        public void Init()
        {
            fakeRepository = new FakeRepositorioComponente();
            componente = new Componente();
            componente.Precio = 20;

            Assert.IsNotNull(componente);
            Assert.AreEqual(20, componente.Precio);
            fakeRepository.AgregarComponente(componente);
        }

        [TestMethod()]
        public void AgregarComponente()
        {
            if (fakeRepository != null) 
            {
                Componente nuevoComp = new()
                {
                    Descripcion = "Memoria RAM Kingston 16 GB",
                    NumSerie = "K16GBYUT",
                    Gigas = 16,
                    Cores = 0,
                    Tipo = EnumComponente.Memoria,
                    Calor = 18,
                    Precio = 39
                };
                fakeRepository.AgregarComponente(nuevoComp);

                Assert.IsNotNull(nuevoComp);
                Assert.AreEqual(39, nuevoComp.Precio);
                Assert.AreEqual(3, fakeRepository.ListarComponentes().Count);
            }
        }

        [TestMethod()]
        public void BorrarComponente()
        {
            if (fakeRepository != null)
            {
                fakeRepository.BorrarComponente(1);
                Assert.AreEqual(1, fakeRepository.ListarComponentes().Count);
            }
        }

        [TestMethod()]
        public void ListarComponentes()
        {
            if (fakeRepository != null)
            {
                List<Componente> listaComponentes = fakeRepository.ListarComponentes();
                Assert.IsNotNull(listaComponentes);
                Assert.AreEqual(2, listaComponentes.Count);
            }
        }

        [TestMethod()]
        public void ConsultarComponente()
        {
            if (fakeRepository != null)
            {
                Componente compConsultado = fakeRepository.ConsultarComponente(1);
                Assert.IsNotNull(compConsultado);
            }
        }

        [TestMethod()]
        public void EditarComponente()
        {
            if (fakeRepository != null)
            {
                var compAEditar = fakeRepository.ConsultarComponente(1);
                fakeRepository.EditarComponente(compAEditar);

                Assert.IsNotNull(compAEditar);
                Assert.AreEqual(1, compAEditar.Id);
                Assert.AreEqual("Procesador Intel i7", compAEditar.Descripcion);
                Assert.AreEqual("789_XCS", compAEditar.NumSerie);
                Assert.AreEqual(EnumComponente.Memoria, compAEditar.Tipo);
                Assert.AreEqual(9, compAEditar.Cores);
                Assert.AreEqual(0, compAEditar.Gigas);
                Assert.AreEqual(10, compAEditar.Calor);
                Assert.AreEqual(134, compAEditar.Precio);
            }
        }
    }
}