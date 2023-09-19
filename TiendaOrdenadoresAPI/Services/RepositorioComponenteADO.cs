using Microsoft.Data.SqlClient;
using TiendaOrdenadoresAPI.Data;
using TiendaOrdenadoresAPI.Mappers;
using TiendaOrdenadoresAPI.Models;
using TiendaOrdenadoresAPI.Services.Consultas;

namespace TiendaOrdenadoresAPI.Services
{
    public class RepositorioComponenteADO : IRepositorio<Componente>
    {
        private readonly SqlConnection _conexion;
        private readonly IMapper<Componente> _mapper;
        private readonly ConsultasComponente _consultas;

        public RepositorioComponenteADO(ADOContext context)
        {
            _mapper = new MapperComponente();
            _conexion = context.GetConnection();
            _consultas = new ConsultasComponente();
        }

        public void Actualizar(Componente comp)
        {
            string sql = _consultas.Editar(comp);
            SqlCommand command = new SqlCommand(sql, _conexion);

            _conexion.Open();
            command.ExecuteNonQuery();
            _conexion.Close();
        }

        public void Añadir(Componente comp)
        {
            string sql = _consultas.Agregar(comp);
            SqlCommand command = new SqlCommand(sql, _conexion);

            _conexion.Open();
            command.ExecuteNonQuery();
            _conexion.Close();
        }

        public void Borrar(int id)
        {
            string sql = _consultas.Borrar(id);
            SqlCommand command = new SqlCommand(sql, _conexion);

            _conexion.Open();
            command.ExecuteNonQuery();
            _conexion.Close();
        }

        public Componente? Obtener(int id)
        {
            Componente? componente;
            string sql = _consultas.Consultar(id);
            SqlCommand command = new SqlCommand(sql, _conexion);

            _conexion.Open();
            SqlDataReader dataReader = command.ExecuteReader();
            if (dataReader.Read())
            {
                componente = _mapper.Map(dataReader);
            }
            else
            {
                componente = null;
            }
            _conexion.Close();

            return componente;
        }

        public List<Componente> ObtenerTodos()
        {
            var componentes = new List<Componente>();
            string sql = _consultas.ListarTodos();
            SqlCommand command = new(sql, _conexion);

            _conexion.Open();
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                componentes.Add(_mapper.Map(dataReader));
            }
            _conexion.Close();

            return componentes;
        }

        public int ObtenerUltimoId()
        {
            int id;

            string sql = _consultas.ObtenerUltimoId();
            SqlCommand command = new SqlCommand(sql, _conexion);

            _conexion.Open();
            SqlDataReader dataReader = command.ExecuteReader();
            if (dataReader.Read())
            {
                id = Convert.ToInt32(dataReader["Id"]);
            }
            else
            {
                id = 0;
            }
            _conexion.Close();

            return id;
        }
    }
}
