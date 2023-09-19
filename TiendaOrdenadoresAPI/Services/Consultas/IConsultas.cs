namespace TiendaOrdenadoresAPI.Services.Consultas
{
    public interface IConsultas<T>
    {
        public string Editar(T item);
        public string Agregar(T item);
        public string Borrar(int id);
        public string Consultar(int id);
        public string ListarTodos();
        public string ObtenerUltimoId();
    }
}
