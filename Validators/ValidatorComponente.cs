using ComponentesMVC.Models;
using ComponentesMVC.Services;

namespace ComponentesMVC.Validators
{
    public class ValidatorComponente
    {
        private readonly IRepositorioComponente? repositorio;

        public ValidatorComponente(IRepositorioComponente repositorio)
        {
            this.repositorio = repositorio;
        }

        public bool IsValid(Componente componente)
        {
            switch (componente.Tipo)
            {
                case EnumComponente.Memoria:
                    if (repositorio != null)
                    {
                        int repMemorias = repositorio.ListarComponentes().Count(c => c.Tipo == componente.Tipo
                            && c.OrdenadorId == componente.OrdenadorId
                            && c.OrdenadorId > 1);
                        return(repMemorias == 0);
                    }
                    return false;

                case EnumComponente.Procesador:
                    if (repositorio != null)
                    {
                        int repProcesadores = repositorio.ListarComponentes().Count(c => c.Tipo == componente.Tipo
                            && c.OrdenadorId == componente.OrdenadorId
                            && c.OrdenadorId > 1);
                        return (repProcesadores == 0);
                    }
                    return false;

                case EnumComponente.Disco:
                    return true;
                default:
                    return false;
            }
        }
    }
}