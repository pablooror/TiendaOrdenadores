using TiendaOrdenadoresAPI.Models;

namespace TiendaOrdenadoresAPI.Services.Consultas
{
    public class ConsultasComponente : IConsultas<Componente>
    {
        public string Editar(Componente componente)
        {
            return "UPDATE Componentes SET " +
                   $"NumSerie = '{componente.NumSerie}', Descripcion = '{componente.Descripcion}'," +
                   $"Tipo = '{(int)componente.Tipo}', Cores = '{componente.Cores}'," +
                   $"Gigas = '{componente.Gigas}', Calor = '{componente.Calor}'," +
                   $"Precio = '{componente.Precio}', OrdenadorId = '{componente.OrdenadorId}'" +
                   $"WHERE Id = {componente.Id}";
        }

        public string Agregar(Componente componente)
        {
            return "INSERT INTO Componentes (NumSerie, Descripcion, Tipo, Cores, Gigas, Calor, Precio, OrdenadorId)" +
                   "VALUES" +
                   $"('{componente.NumSerie}', '{componente.Descripcion}', '{(int)componente.Tipo}', '{componente.Cores}', " +
                   $"'{componente.Gigas}', '{componente.Calor}', '{componente.Precio}', {componente.OrdenadorId})";
        }

        public string Borrar(int id)
        {
            return $"DELETE FROM Componentes WHERE Id = {id}";
        }

        public string Consultar(int id)
        {
            return $"SELECT * FROM Componentes WHERE Id = {id}";
        }

        public string ListarTodos()
        {
            return $"SELECT * FROM Componentes";
        }

        public string ObtenerUltimoId()
        {
            return "SELECT MAX(Id) AS Id FROM Componentes";
        }
    }
}
