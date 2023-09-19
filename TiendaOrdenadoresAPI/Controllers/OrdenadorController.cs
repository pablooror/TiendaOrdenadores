using Microsoft.AspNetCore.Mvc;
using TiendaOrdenadoresAPI.Models;
using TiendaOrdenadoresAPI.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TiendaOrdenadoresAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenadorController : ControllerBase
    {
        private readonly IRepositorio<Ordenador> _repositorio;

        public OrdenadorController(IRepositorio<Ordenador> repositorio)
        {
            _repositorio = repositorio;
        }

        // GET: api/<OrdenadorController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repositorio.ObtenerTodos());
        }

        // GET api/<OrdenadorController>/5
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

        // POST api/<OrdenadorController>
        [HttpPost]
        public IActionResult Post([FromBody] Ordenador ordenador)
        {
            _repositorio.Añadir(ordenador);
            return Ok();
        }

        // PUT api/<OrdenadorController>/5
        [HttpPut()]
        public IActionResult Put([FromBody] Ordenador ordenador)
        {
            if (_repositorio.Obtener(ordenador.Id) == null)
            {
                return BadRequest(504);
            }
            _repositorio.Actualizar(ordenador);
            return Ok();
        }

        // DELETE api/<OrdenadorController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repositorio.Borrar(id);
            return Ok();
        }
    }
}
