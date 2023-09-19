using TiendaOrdenadoresAPI.Models;

namespace TiendaOrdenadoresAPI.Services
{
    public class FakeRepositoryComponente : IRepositorio<Componente>
    {
        readonly List<Componente> listaComp = new();
        public FakeRepositoryComponente()
        {
            listaComp.Add(new Componente()
            {
                Id = 1,
                NumSerie = "789_XCS",
                Descripcion = "Procesador Intel i7",
                Gigas = 0,
                Cores = 9,
                Calor = 10,
                Precio = 134.0,
                Tipo = EnumComponente.Procesador,
                OrdenadorId = 1
            });

            listaComp.Add(new Componente()
            {
                Id = 2,
                NumSerie = "879FH",
                Descripcion = "Banco de memoria SDRAM",
                Gigas = 512,
                Cores = 0,
                Calor = 10,
                Precio = 100.0,
                Tipo = EnumComponente.Memoria,
                OrdenadorId = 1
            });

            listaComp.Add(new Componente()
            {
                Id = 3,
                NumSerie = "789_XX",
                Descripcion = "Disco Duro Scan Disk",
                Gigas = 500000,
                Cores = 0,
                Calor = 10,
                Precio = 50.0,
                Tipo = EnumComponente.Disco,
                OrdenadorId = 1
            });
        }

        public List<Componente> ObtenerTodos()
        {
            return listaComp;
        }

        public Componente? Obtener(int Id)
        {
            if (Id < 0 || Id > listaComp.Count)
            {
                return null;
            }
            return listaComp.First(x => x.Id == Id);
        }

        public void Añadir(Componente item)
        {
            listaComp.Add(item);
        }

        public void Borrar(int id)
        {
            var compABorrar = listaComp.First(comp => comp.Id == id);
            if (compABorrar != null)
            {
                listaComp.Remove(compABorrar);
            }
        }

        public void Actualizar(Componente componente)
        {
            var compAEditar = Obtener(componente.Id);
            if (compAEditar != null)
            {
                compAEditar.NumSerie = componente.NumSerie;
                compAEditar.Descripcion = componente.Descripcion;
                compAEditar.Gigas = componente.Gigas;
                compAEditar.Cores = componente.Cores;
                compAEditar.Calor = componente.Calor;
                compAEditar.Precio = componente.Precio;
                compAEditar.Tipo = componente.Tipo;
            }
        }

        public int ObtenerUltimoId()
        {
            return 0;
        }
    }
}