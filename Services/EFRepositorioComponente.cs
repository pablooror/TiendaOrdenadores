using ComponentesMVC.Data.Logs;
using ComponentesMVC.Models;
using ComponentesMVC.Validators;

namespace ComponentesMVC.Services
{
    public class EFRepositorioComponente : IRepositorioComponente
    {
        readonly DesignTimeComponenteContextFactory factoriaContextos = new();
        readonly TiendaOrdenadoresContext contexto;
        readonly ILoggerManager _loggerManager;

        public EFRepositorioComponente(ILoggerManager loggerManager)
        {
            _loggerManager = loggerManager;
            _loggerManager.LogInfo("Cargando logger...");
            string[] args = new string[1];
            contexto = factoriaContextos.CreateDbContext(args);
        }

        public void AgregarComponente(Componente componente)
        {
            if (contexto.Componentes is not null)
            {
                try
                {
                    contexto.Componentes.Add(componente);
                    _loggerManager.LogInfo($"Componente {componente.Id} añadido. Núm. Serie: {componente.NumSerie}");

                    Ordenador? ordenador = contexto.Ordenadores.FirstOrDefault(o => o.Id == componente.Id);
                    if (ordenador != null) ordenador.Precio += componente.Precio;
                    contexto.SaveChanges();
                }
                catch
                {
                    _loggerManager.LogError("Componente no válido para crear.");
                }
            }
        }

        public void BorrarComponente(int Id)
        {
            if (contexto.Componentes is not null)
            {
                var compBuscado = ConsultarComponente(Id);
                if (compBuscado is not null)
                {
                    contexto.Componentes.Remove(compBuscado);
                    contexto.SaveChanges();
                    _loggerManager.LogInfo($"Componente {compBuscado.Id} eliminado.");
                }
                else
                {
                    _loggerManager.LogError("Componente a borrar no encontrado");
                }
            }
        }

        public Componente? ConsultarComponente(int Id)
        {
            var listaComp = ListarComponentes();
            
            if (contexto.Componentes is not null && listaComp != null)
            {
                var compBuscado = listaComp.Find(c => c.Id == Id);
                _loggerManager.LogInfo($"Buscando componente nº {Id} ...");
                return compBuscado;
            }
            else
            {
                _loggerManager.LogError($"Componente nº {Id} no encontrado");
            }
            return null;
        }

        public void EditarComponente(Componente componente)
        {
            var compAEditar = ConsultarComponente(componente.Id);
            if (contexto.Componentes is not null && compAEditar != null)
            {
                _loggerManager.LogInfo($"Editando componente nº {componente.Id}...");
                compAEditar.NumSerie = componente.NumSerie;
                compAEditar.Descripcion = componente.Descripcion;
                compAEditar.Tipo = componente.Tipo;
                compAEditar.Cores = componente.Cores;
                compAEditar.Gigas = componente.Gigas;
                compAEditar.Calor = componente.Calor;
                compAEditar.Precio = componente.Precio;
                compAEditar.OrdenadorId = componente.OrdenadorId;
                _loggerManager.LogInfo($"Componente nº {componente.Id} editado correctamente.");

                Ordenador? ordenador = contexto.Ordenadores.FirstOrDefault(o => o.Id == compAEditar.OrdenadorId);
                if (ordenador != null) ordenador.Precio += compAEditar.Precio;

                contexto.SaveChanges();
            }
            else
            {
                _loggerManager.LogInfo($"No se puede editar el componente nº {componente.Id}.");
            }
        }

        public List<Componente> ListarComponentes()
        {
            _loggerManager.LogInfo("Mostrando tabla de componentes");
            return contexto.Componentes.ToList();
        }
    }
}
