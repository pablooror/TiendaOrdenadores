using ComponentesMVC.Models;

namespace ComponentesMVC.Services
{
    public class ValidatorComponente
    {
        private readonly IRepositorioComponente? _reposComp;

        public ValidatorComponente(IRepositorioComponente reposComp)
        {
            _reposComp = reposComp;
        }

        public bool IsValid(Componente componente)
        {
            var tipo = componente.Tipo;
            if (_reposComp != null)
            {
                int conteoMismoPc = _reposComp.ListarComponentes().Count(c  => c.Tipo == componente.Tipo && c.OrdenadorId > 1 && c.OrdenadorId == componente.OrdenadorId);
                return tipo switch
                {
                    EnumComponente.Memoria => (conteoMismoPc < 1),
                    EnumComponente.Procesador => (conteoMismoPc < 1),
                    EnumComponente.Disco => true,
                    _ => false
                };
            }
            else
            {
                return false;
            }
        }
    }
}
