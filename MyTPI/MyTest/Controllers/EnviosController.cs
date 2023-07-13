using Microsoft.AspNetCore.Mvc;
using Model.DTOs;
using Model.Models;
using Service.Iservices;

namespace MyTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnviosController : ControllerBase
    {
        private readonly IEnviosService _enviosService;

        public EnviosController(IEnviosService enviosService)
        {
            _enviosService = enviosService;
        }

        // GET: api/Envios
        [HttpGet]
        public IActionResult Get()
        {
            var envios = _enviosService.GetAllEnvios();
            return Ok(envios);
        }

        // GET: api/Envios/{id}
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var envio = _enviosService.GetEnvioById(id);
            if (envio == null)
            {
                return NotFound();
            }
            return Ok(envio);
        }

        // POST: api/Envios
        [HttpPost]
        public  IActionResult Post([FromBody] EnvioDTOs envio)
        {
            var nuevoEnvio =  _enviosService.CreateEnvio(envio);
            return CreatedAtAction(nameof(Get), new { id = nuevoEnvio.IdEnvio }, nuevoEnvio);
        }

        // PUT: api/Envios/{id}
        [HttpPut("{id}")]
        public  IActionResult Put(int id, [FromBody] EnvioDTOs envio)
        {
            var updatedEnvio =  _enviosService.UpdateEnvio(id, envio);
            if (updatedEnvio == null)
            {
                return NotFound();
            }
            return Ok(updatedEnvio);
        }

        // DELETE: api/Envios/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
             _enviosService.DeleteEnvio(id);
            return Ok();
        }
    }
}