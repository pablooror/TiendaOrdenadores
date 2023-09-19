using ComponentesMVC.Models;

namespace ComponentesMVC.Services
{
    public class FakeRepositorioOrdenador : IRepositorioOrdenador
    {
        readonly List<Ordenador> listaPc = new();
        readonly List<Componente> listaComp = new();
        public FakeRepositorioOrdenador()
        {
            listaPc.Add(new Ordenador()
            {
                Id = 1,
                Descripcion = "Ordenador 1",
                Precio = 250,
                PedidoId = 1
            });

            listaComp.Add(new Componente()
            {
                Descripcion = "Memoria Kingston 8GB",
                Gigas = 8,
                Calor = 10,
                NumSerie = "K8GBUIP",
                Precio = 21,
                OrdenadorId = 1
            });
        }
        
        public void AgregarOrdenador(Ordenador ordenador)
        {
            listaPc.Add(ordenador);
        }

        public void BorrarOrdenador(int Id)
        {
            listaPc.RemoveAt(Id);
        }

        public List<Ordenador> ListarOrdenadores()
        {
            return listaPc;
        }

        public List<Componente> ListarCompDelPc(Ordenador ordenador)
        {
            return listaComp.FindAll(c => c.OrdenadorId == ordenador.Id);
        }

        public Ordenador Ordenador(int Id)
        {
            return listaPc.First(x => x.Id == Id);
        }

        public void EditarOrdenador(Ordenador ordenador)
        {
            var pcAEditar = ConsultarOrdenador(ordenador.Id);
            if (pcAEditar != null)
            {
                pcAEditar.Descripcion = ordenador.Descripcion;
                pcAEditar.Precio = ordenador.Precio;
            }
        }

        public Ordenador? ConsultarOrdenador(int Id)
        {
            var ordenadorBuscado = listaPc.Find(o => o.Id == Id);
            return ordenadorBuscado;
        }
    }
}
