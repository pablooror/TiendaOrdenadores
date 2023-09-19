using ComponentesMVC.Models;

namespace ComponentesMVC.ViewModels
{
    public class ListaComponentesViewModel
    {
        public IOrderedEnumerable<Componente> ListaComponentes { get; set; }
    }
}
