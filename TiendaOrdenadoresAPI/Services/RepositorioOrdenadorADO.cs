using Microsoft.Data.SqlClient;
using TiendaOrdenadoresAPI.Data;
using TiendaOrdenadoresAPI.Mappers;
using TiendaOrdenadoresAPI.Models;
using TiendaOrdenadoresAPI.Services.Consultas;

namespace TiendaOrdenadoresAPI.Services
{
    public class RepositorioOrdenadorADO : IRepositorio<Ordenador>
    {
        private readonly SqlConnection _conexion;
        private readonly IMapper<Ordenador> _mapper;
        private readonly IMapper<Componente> _mapperComp;
        private readonly ConsultasOrdenador _consultas;

        public RepositorioOrdenadorADO(ADOContext context)
        {
            _mapper = new MapperOrdenador();
            _mapperComp = new MapperComponente(); 
            _conexion = context.GetConnection();
            _consultas = new ConsultasOrdenador();
        }

        public void Actualizar(Ordenador pc)
        {
            string sql = _consultas.Editar(pc);
            SqlCommand command = new SqlCommand(sql, _conexion);

            _conexion.Open();
            command.ExecuteNonQuery();
            _conexion.Close();
        }

        public void Añadir(Ordenador pc)
        {
            string sql = _consultas.Agregar(pc);
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

        public List<Componente> ObtenerCompPC(Ordenador pc)
        {
            var componentes = new List<Componente>();
            string sql = _consultas.ComponentesDelPc(pc);
            SqlCommand command = new(sql, _conexion);

            _conexion.Open();
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                componentes.Add(_mapperComp.Map(dataReader));
            }
            _conexion.Close();

            return componentes;
        }

        public Ordenador? Obtener(int id)
        {
            Ordenador? ordenador;
            string sql = _consultas.Consultar(id);
            SqlCommand command = new SqlCommand(sql, _conexion);

            _conexion.Open();
            SqlDataReader dataReader = command.ExecuteReader();
            if (dataReader.Read())
            {
                ordenador = _mapper.Map(dataReader);
            }
            else
            {
                ordenador = null;
            }
            _conexion.Close();

            return ordenador;
        }

        public List<Ordenador> ObtenerTodos()
        {
            var ordenadores = new List<Ordenador>();
            string sql = _consultas.ListarTodos();
            SqlCommand command = new(sql, _conexion);

            _conexion.Open();
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                ordenadores.Add(_mapper.Map(dataReader));
            }
            _conexion.Close();

            return ordenadores;
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
