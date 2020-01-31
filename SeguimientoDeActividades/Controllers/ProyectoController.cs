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
    public class ProyectoController : ControllerBase
    {
        private readonly SeguimientoActividadesBDContext _context;

        public ProyectoController(SeguimientoActividadesBDContext context)
        {
            _context = context;
        }

        // GET: api/Proyecto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Proyecto>>> GetProyecto()
        {
            return await _context.Proyectos.ToListAsync();
        }

        // GET: api/Proyecto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Proyecto>> GetProyecto(int id)
        {
            var proyecto = await _context.Proyectos.FindAsync(id);

            if (proyecto == null)
            {
                return NotFound();
            }

            return proyecto;
        }

        // PUT: api/Proyecto/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProyecto(int id, Proyecto proyecto)
        {
            if (id != proyecto.Idproyecto)
            {
                return BadRequest();
            }

            _context.Entry(proyecto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProyectoExists(id))
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

        // POST: api/Proyecto
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Proyecto>> PostProyecto(Proyecto proyecto)
        {
            _context.Proyectos.Add(proyecto);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProyectoExists(proyecto.Idproyecto))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProyecto", new { id = proyecto.Idproyecto }, proyecto);
        }

        // DELETE: api/Proyecto/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Proyecto>> DeleteProyecto(int id)
        {
            var proyecto = await _context.Proyectos.FindAsync(id);
            if (proyecto == null)
            {
                return NotFound();
            }

            _context.Proyectos.Remove(proyecto);
            await _context.SaveChangesAsync();

            return proyecto;
        }

        private bool ProyectoExists(int id)
        {
            return _context.Proyectos.Any(e => e.Idproyecto == id);
        }
    }
}
