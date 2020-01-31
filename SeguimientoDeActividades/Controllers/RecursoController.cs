using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeguimientoDeActividades.Models;

namespace SeguimientoDeActividades.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecursoController : ControllerBase
    {
        private readonly SeguimientoActividadesBDContext _context;

        public RecursoController(SeguimientoActividadesBDContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Recurso> PruebaConexion()
        {
            return new List<Recurso>()
            {
                new Recurso{Idrecurso=1,RecursoNombre="camilo",Recursodisponibilidad=24,Recursocorreo="asdasd"},
               new Recurso{Idrecurso=2,RecursoNombre="Andres",Recursodisponibilidad=12,Recursocorreo="asdasad"}
            };
        }
        // GET: api/Recurso
        ////[HttpGet]
        ////public async Task<ActionResult<IEnumerable<Recurso>>> GetRecurso()
        ////{
        ////    return await _context.Recurso.ToListAsync();
        ////}

        // GET: api/Recurso/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Recurso>> GetRecurso(int id)
        {
            var recurso = await _context.Recursos.FindAsync(id);

            if (recurso == null)
            {
                return NotFound();
            }

            return recurso;
        }

        // PUT: api/Recurso/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecurso(int id, Recurso recurso)
        {
            if (id != recurso.Idrecurso)
            {
                return BadRequest();
            }

            _context.Entry(recurso).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecursoExists(id))
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

        // POST: api/Recurso
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Recurso>> PostRecurso(Recurso recurso)
        {
            _context.Recursos.Add(recurso);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRecurso", new { id = recurso.Idrecurso }, recurso);
        }

        // DELETE: api/Recurso/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Recurso>> DeleteRecurso(int id)
        {
            var recurso = await _context.Recursos.FindAsync(id);
            if (recurso == null)
            {
                return NotFound();
            }

            _context.Recursos.Remove(recurso);
            await _context.SaveChangesAsync();

            return recurso;
        }

        private bool RecursoExists(int id)
        {
            return _context.Recursos.Any(e => e.Idrecurso == id);
        }
    }
}
