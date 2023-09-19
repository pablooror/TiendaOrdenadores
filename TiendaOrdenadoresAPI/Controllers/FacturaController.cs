using Microsoft.AspNetCore.Mvc;
using TiendaOrdenadoresAPI.Models;
using TiendaOrdenadoresAPI.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TiendaOrdenadoresAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private readonly IRepositorio<Factura> _repositorio;

        public FacturaController(IRepositorio<Factura> repositorio)
        {
            _repositorio = repositorio;
        }

        // GET: api/<FacturaController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repositorio.ObtenerTodos());
        }

        // GET api/<FacturaController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var factura = _repositorio.Obtener(id);

            if (factura == null)
            {
                return NotFound();
            }

            return Ok(factura);
        }

        // POST api/<FacturaController>
        [HttpPost]
        public IActionResult Post([FromBody] Factura factura)
        {
            _repositorio.Añadir(factura);
            return Ok();
        }

        // PUT api/<FacturaController>/5
        [HttpPut()]
        public IActionResult Put([FromBody] Factura factura)
        {
            if (_repositorio.Obtener(factura.Id) == null)
            {
                return BadRequest(504);
            }
            _repositorio.Actualizar(factura);
            return Ok();
        }

        // DELETE api/<FacturaController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repositorio.Borrar(id);
            return Ok();
        }
    }
}
