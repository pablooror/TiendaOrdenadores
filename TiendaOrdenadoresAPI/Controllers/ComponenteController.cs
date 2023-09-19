using Microsoft.AspNetCore.Mvc;
using TiendaOrdenadoresAPI.Models;
using TiendaOrdenadoresAPI.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TiendaOrdenadoresAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComponenteController : ControllerBase
    {
        private readonly IRepositorio<Componente> _repositorio;

        public ComponenteController(IRepositorio<Componente> repositorio)
        {
            _repositorio = repositorio;
        }

        // GET: api/<ComponenteController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repositorio.ObtenerTodos());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var componente = _repositorio.Obtener(id);

            if (componente == null)
            {
                return NotFound();
            }

            return Ok(componente);
        }

        // POST api/<ComponenteController>
        [HttpPost]
        public IActionResult Post([FromBody] Componente componente)
        {
            _repositorio.Añadir(componente);
            return Ok();
        }

        // PUT api/<ComponenteController>/5
        [HttpPut()]
        public IActionResult Put([FromBody] Componente componente)
        {
            if (_repositorio.Obtener(componente.Id) == null)
            {
                return BadRequest(504);
            }
            _repositorio.Actualizar(componente);
            return Ok();
        }

        // DELETE api/<ComponenteController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repositorio.Borrar(id);
            return Ok();
        }
    }
}
