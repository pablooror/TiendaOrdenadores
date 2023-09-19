using Microsoft.AspNetCore.Mvc;
using TiendaOrdenadoresAPI.Models;
using TiendaOrdenadoresAPI.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TiendaOrdenadoresAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IRepositorio<Pedido> _repositorio;

        public PedidoController(IRepositorio<Pedido> repositorio)
        {
            _repositorio = repositorio;
        }

        // GET: api/<PedidoController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repositorio.ObtenerTodos());
        }

        // GET api/<PedidoController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var ordenador = _repositorio.Obtener(id);

            if (ordenador == null)
            {
                return NotFound();
            }

            return Ok(ordenador);
        }

        // POST api/<PedidoController>
        [HttpPost]
        public IActionResult Post([FromBody] Pedido pedido)
        {
            _repositorio.Añadir(pedido);
            return Ok();
        }

        // PUT api/<PedidoController>/5
        [HttpPut()]
        public IActionResult Put([FromBody] Pedido pedido)
        {
            if (_repositorio.Obtener(pedido.Id) == null)
            {
                return BadRequest(504);
            }
            _repositorio.Actualizar(pedido);
            return Ok();
        }

        // DELETE api/<PedidoController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repositorio.Borrar(id);
            return Ok();
        }
    }
}