using ComponentesMVC.Models;

namespace ComponentesMVC.Services
{
    public interface IRepositorioOrdenador
    {
        Ordenador? ConsultarOrdenador(int Id);
        void BorrarOrdenador(int Id);
        void EditarOrdenador(Ordenador ordenador);
        void AgregarOrdenador(Ordenador ordenador);
        List<Ordenador>? ListarOrdenadores();
        List<Componente>? ListarCompDelPc(Ordenador ordenador);
    }
}
