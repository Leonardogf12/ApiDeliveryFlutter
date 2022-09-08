using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiDeliveryFlutter.Data;
using ApiDeliveryFlutter.models;

namespace ApiDeliveryFlutter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiCategoriaController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public ApiCategoriaController(ApiDbContext context)
        {
            _context = context;
        }

        #region GETS
        // GET: api/Categoria
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categoria>>> GetCategoria()
        {
            if (_context.Categoria == null)
            {
                return NotFound();
            }
            return await _context.Categoria.ToListAsync();
        }

        // GET: api/Categoria/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Categoria>> GetCategoria(int id)
        {
            if (_context.Categoria == null)
            {
                return NotFound();
            }
            var categoria = await _context.Categoria.FindAsync(id);

            if (categoria == null)
            {
                return NotFound();
            }

            return categoria;
        }

        private bool CategoriaExists(int id)
        {
            return (_context.Categoria?.Any(e => e.id == id)).GetValueOrDefault();
        }

        #endregion

        #region POSTS
        // PUT: api/Categoria/id        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoria(int id, Categoria categoria)
        {
            if (id != categoria.id)
            {
                return BadRequest();
            }

            _context.Entry(categoria).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Categoria       
        [HttpPost]
        public async Task<ActionResult<Categoria>> PostCategoria(Categoria categoria)
        {
            if (_context.Categoria == null)
            {
                return Problem("Ocorreu um probleme com a class de Categoria");
            }
            _context.Categoria.Add(categoria);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategoria", new { id = categoria.id }, categoria);
        }

        // DELETE: api/Categoria/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoria(int id)
        {
            if (_context.Categoria == null)
            {
                return NotFound();
            }
            var categoria = await _context.Categoria.FindAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }

            _context.Categoria.Remove(categoria);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        #endregion

    }
}
