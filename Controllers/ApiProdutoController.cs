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
    public class ApiProdutoController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public ApiProdutoController(ApiDbContext context)
        {
            _context = context;
        }

        #region GETS
        // GET: api/ApiProduto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> GetProduto()
        {
          if (_context.Produto == null)
          {
              return NotFound();
          }
            return await _context.Produto.ToListAsync();
        }

        // GET: api/ApiProduto/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> GetProduto(int id)
        {
          if (_context.Produto == null)
          {
              return NotFound();
          }
            var produto = await _context.Produto.FindAsync(id);

            if (produto == null)
            {
                return NotFound();
            }

            return produto;
        }

        private bool ProdutoExists(int id)
        {
            return (_context.Produto?.Any(e => e.id == id)).GetValueOrDefault();
        }
        #endregion

        #region POSTS

        // PUT: api/ApiProduto/id        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduto(int id, Produto produto)
        {
            if (id != produto.id)
            {
                return BadRequest();
            }

            _context.Entry(produto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutoExists(id))
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

        // POST: api/ApiProduto       
        [HttpPost]
        public async Task<ActionResult<Produto>> PostProduto(Produto produto)
        {
          if (_context.Produto == null)
          {
              return Problem("Ocorreu um problema com a class de Produto");
          }
            _context.Produto.Add(produto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduto", new { id = produto.id }, produto);
        }

        // DELETE: api/ApiProduto/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduto(int id)
        {
            if (_context.Produto == null)
            {
                return NotFound();
            }
            var produto = await _context.Produto.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }

            _context.Produto.Remove(produto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        #endregion
    }
}
