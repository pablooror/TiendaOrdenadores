using ComponentesMVC.Models;

namespace ComponentesMVC.Services
{
    public interface IRepositorioComponente
    {
        Componente? ConsultarComponente(int Id);
        void BorrarComponente(int Id);
        void AgregarComponente(Componente componente);
        void EditarComponente(Componente componente);
        List<Componente>? ListarComponentes();
    }
}
