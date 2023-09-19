using TiendaOrdenadoresAPI.Models;

namespace TiendaOrdenadoresAPI.Services
{
    public class FakeRepositoryOrdenador : IRepositorio<Ordenador>
    {
        readonly List<Ordenador> listaPc = new();
        public FakeRepositoryOrdenador()
        {
            listaPc.Add(new Ordenador()
            {
                Id = 1,
                Descripcion = "Ordenador 1",
                Precio = 284.0,
                PedidoId = 1
            });
        }

        public List<Ordenador> ObtenerTodos()
        {
            return listaPc;
        }

        public Ordenador? Obtener(int Id)
        {
            if (Id < 0 || Id > listaPc.Count)
            {
                return null;
            }
            return listaPc.First(x => x.Id == Id);
        }

        public void Añadir(Ordenador item)
        {
            listaPc.Add(item);
        }

        public void Borrar(int id)
        {
            var pcABorrar = listaPc.First(pc => pc.Id == id);
            if (pcABorrar != null)
            {
                listaPc.Remove(pcABorrar);
            }
        }

        public void Actualizar(Ordenador ordenador)
        {
            var pcAEditar = Obtener(ordenador.Id);
            if (pcAEditar != null)
            {
                pcAEditar.Descripcion = ordenador.Descripcion;
                pcAEditar.Precio = ordenador.Precio;
                pcAEditar.PedidoId = ordenador.PedidoId;
            }
        }

        public int ObtenerUltimoId()
        {
            return 0;
        }
    }
}