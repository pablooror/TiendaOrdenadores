namespace TiendaOrdenadoresAPI.Services
{
    public interface IRepositorio<T> where T : class
    {
        List<T> ObtenerTodos();
        T? Obtener(int id);
        void Añadir(T item);
        void Borrar(int id);
        void Actualizar(T element);
        int ObtenerUltimoId();
    }
}
