using ComponentesMVC.Models;

namespace ComponentesMVC.Services
{
    public class FakeRepositorioComponente : IRepositorioComponente
    {
        readonly List<Componente> listaComp = new();
        public FakeRepositorioComponente()
        {
            listaComp.Add(new Componente()
            {
                Id = 1,
                NumSerie = "789_XCS",
                Descripcion = "Procesador Intel i7",
                Calor = 10,
                Gigas = 0,
                Cores = 9,
                Precio = 134.0,
                Tipo = EnumComponente.Procesador
            });

        }
        
        public void AgregarComponente(Componente componente)
        {
            listaComp.Add(componente);
        }

        public void BorrarComponente(int Id)
        {
            listaComp.RemoveAt(Id);
        }

        public List<Componente> ListarComponentes()
        {
            return listaComp;
        }
        
        public Componente ConsultarComponente(int Id)
        {
            return listaComp.First(x => x.Id == Id);
        }

        public void EditarComponente(Componente componente)
        {
            var CompAEditar = ConsultarComponente(componente.Id);
            if (CompAEditar != null)
            {
                CompAEditar.NumSerie = componente.NumSerie;
                CompAEditar.Descripcion = componente.Descripcion;
                CompAEditar.Tipo = componente.Tipo;
                CompAEditar.Cores = componente.Cores;
                CompAEditar.Gigas = componente.Gigas;
                CompAEditar.Calor = componente.Calor;
                CompAEditar.Precio = componente.Precio;
            }
        }
    }
}
