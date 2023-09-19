using Microsoft.Data.SqlClient;
using TiendaOrdenadoresAPI.Data;
using TiendaOrdenadoresAPI.Mappers;
using TiendaOrdenadoresAPI.Models;
using TiendaOrdenadoresAPI.Services.Consultas;

namespace TiendaOrdenadoresAPI.Services
{
    public class RepositorioFacturaADO : IRepositorio<Factura>
    {
        private readonly SqlConnection _conexion;
        private readonly IMapper<Factura> _mapper;
        private readonly IMapper<Pedido> _maperPedido;
        private readonly ConsultasFactura _consultas;

        public RepositorioFacturaADO(ADOContext context)
        {
            _mapper = new MapperFactura();
            _maperPedido = new MapperPedido(); 
            _conexion = context.GetConnection();
            _consultas = new ConsultasFactura();
        }

        public void Actualizar(Factura factura)
        {
            string sql = _consultas.Editar(factura);
            SqlCommand command = new SqlCommand(sql, _conexion);

            _conexion.Open();
            command.ExecuteNonQuery();
            _conexion.Close();
        }

        public void Añadir(Factura factura)
        {
            string sql = _consultas.Agregar(factura);
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

        public List<Pedido> ObtenerPedidosFactura(Factura factura)
        {
            var pedidos = new List<Pedido>();
            string sql = _consultas.ComponentesDelPedido(factura);
            SqlCommand command = new(sql, _conexion);

            _conexion.Open();
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                pedidos.Add(_maperPedido.Map(dataReader));
            }
            _conexion.Close();

            return pedidos;
        }

        public Factura? Obtener(int id)
        {
            Factura? factura;
            string sql = _consultas.Consultar(id);
            SqlCommand command = new SqlCommand(sql, _conexion);

            _conexion.Open();
            SqlDataReader dataReader = command.ExecuteReader();
            if (dataReader.Read())
            {
                factura = _mapper.Map(dataReader);
            }
            else
            {
                factura = null;
            }
            _conexion.Close();

            return factura;
        }

        public List<Factura> ObtenerTodos()
        {
            var facturas = new List<Factura>();
            string sql = _consultas.ListarTodos();
            SqlCommand command = new(sql, _conexion);

            _conexion.Open();
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                facturas.Add(_mapper.Map(dataReader));
            }
            _conexion.Close();

            return facturas;
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
