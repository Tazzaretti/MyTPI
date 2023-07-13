using Microsoft.AspNetCore.Mvc;
using Model.Models;
using Service.Iservices;

namespace MyTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {
        private readonly IVentasService _ventasService;

        public VentasController(IVentasService ventasService)
        {
            _ventasService = ventasService;
        }

        // GET: api/Ventas
        [HttpGet]
        public IActionResult Get()
        {
            var ventas = _ventasService.GetAllVentas();
            return Ok(ventas);
        }

        // GET: api/Ventas/{id}
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var venta = _ventasService.GetVentaById(id);
            if (venta == null)
            {
                return NotFound();
            }
            return Ok(venta);
        }

        // POST: api/Ventas
        [HttpPost]
        public IActionResult Post([FromBody] Ventas venta)
        {
            var nuevaVenta =  _ventasService.CreateVenta(venta);
            return CreatedAtAction(nameof(Get), new { id = nuevaVenta.IdVenta }, nuevaVenta);
        }

        // PUT: api/Ventas/{id}
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Ventas venta)
        {
            var updatedVenta =  _ventasService.UpdateVenta(id, venta);
            if (updatedVenta == null)
            {
                return NotFound();
            }
            return Ok(updatedVenta);
        }

        // DELETE: api/Ventas/{id}
        [HttpDelete("{id}")]
        public  IActionResult Delete(int id)
        {
             _ventasService.DeleteVenta(id);
            return Ok();
        }
    }
}