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
    public class ApiUsuarioController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public ApiUsuarioController(ApiDbContext context)
        {
            _context = context;
        }

        #region GETS
        // GET: api/ApiUsuario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuario()
        {
          if (_context.Usuario == null)
          {
              return NotFound();
          }
            return await _context.Usuario.ToListAsync();
        }

        // GET: api/ApiUsuario/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
          if (_context.Usuario == null)
          {
              return NotFound();
          }
            var usuario = await _context.Usuario.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        private bool UsuarioExists(int id)
        {
            return (_context.Usuario?.Any(e => e.id == id)).GetValueOrDefault();
        }
        #endregion

        #region POSTS
        // PUT: api/ApiUsuario/id       
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, Usuario usuario)
        {
            if (id != usuario.id)
            {
                return BadRequest();
            }

            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
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

        // POST: api/ApiUsuario        
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
          if (_context.Usuario == null)
          {
              return Problem("Ocorreu um problema com a class de Usuario POST");
          }
            _context.Usuario.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuario", new { id = usuario.id }, usuario);
        }

        // DELETE: api/ApiUsuario/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            if (_context.Usuario == null)
            {
                return NotFound();
            }
            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuario.Remove(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        #endregion

    }
}
