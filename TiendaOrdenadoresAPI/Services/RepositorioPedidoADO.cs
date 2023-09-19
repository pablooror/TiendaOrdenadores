using Microsoft.Data.SqlClient;
using TiendaOrdenadoresAPI.Data;
using TiendaOrdenadoresAPI.Mappers;
using TiendaOrdenadoresAPI.Models;
using TiendaOrdenadoresAPI.Services.Consultas;

namespace TiendaOrdenadoresAPI.Services
{
    public class RepositorioPedidoADO : IRepositorio<Pedido>
    {
        private readonly SqlConnection _conexion;
        private readonly IMapper<Pedido> _mapper;
        private readonly IMapper<Ordenador> _mapperPc;
        private readonly ConsultasPedido _consultas;

        public RepositorioPedidoADO(ADOContext context)
        {
            _mapper = new MapperPedido();
            _mapperPc = new MapperOrdenador(); 
            _conexion = context.GetConnection();
            _consultas = new ConsultasPedido();
        }

        public void Actualizar(Pedido pedido)
        {
            string sql = _consultas.Editar(pedido);
            SqlCommand command = new SqlCommand(sql, _conexion);

            _conexion.Open();
            command.ExecuteNonQuery();
            _conexion.Close();
        }

        public void Añadir(Pedido pedido)
        {
            string sql = _consultas.Agregar(pedido);
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

        public List<Ordenador> ObtenerPcPedido(Pedido pedido)
        {
            var ordenadores = new List<Ordenador>();
            string sql = _consultas.ComponentesDelPedido(pedido);
            SqlCommand command = new(sql, _conexion);

            _conexion.Open();
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                ordenadores.Add(_mapperPc.Map(dataReader));
            }
            _conexion.Close();

            return ordenadores;
        }

        public Pedido? Obtener(int id)
        {
            Pedido? pedido;
            string sql = _consultas.Consultar(id);
            SqlCommand command = new SqlCommand(sql, _conexion);

            _conexion.Open();
            SqlDataReader dataReader = command.ExecuteReader();
            if (dataReader.Read())
            {
                pedido = _mapper.Map(dataReader);
            }
            else
            {
                pedido = null;
            }
            _conexion.Close();

            return pedido;
        }

        public List<Pedido> ObtenerTodos()
        {
            var pedidos = new List<Pedido>();
            string sql = _consultas.ListarTodos();
            SqlCommand command = new(sql, _conexion);

            _conexion.Open();
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                pedidos.Add(_mapper.Map(dataReader));
            }
            _conexion.Close();

            return pedidos;
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
