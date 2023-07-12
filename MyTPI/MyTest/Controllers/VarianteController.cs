﻿using Microsoft.AspNetCore.Mvc;
using Model.Models;
using Service.Iservices;

namespace MyTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VariantesController : ControllerBase
    {
        private readonly IVariantesService _variantesService;

        public VariantesController(IVariantesService variantesService)
        {
            _variantesService = variantesService;
        }

        // GET: api/Variantes
        [HttpGet]
        public IActionResult Get()
        {
            var variantes = _variantesService.GetAllVariantes();
            return Ok(variantes);
        }

        // GET: api/Variantes/{id}
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var variante = _variantesService.GetVarianteById(id);
            if (variante == null)
            {
                return NotFound();
            }
            return Ok(variante);
        }

        // POST: api/Variantes
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Variante variante)
        {
            var nuevaVariante = await _variantesService.CreateVariante(variante);
            return CreatedAtAction(nameof(Get), new { id = nuevaVariante.IdVariante }, nuevaVariante);
        }

        // PUT: api/Variantes/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Variante variante)
        {
            var updatedVariante = await _variantesService.UpdateVariante(id, variante);
            if (updatedVariante == null)
            {
                return NotFound();
            }
            return Ok(updatedVariante);
        }

        // DELETE: api/Variantes/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _variantesService.DeleteVariante(id);
            return Ok();
        }
    }
}