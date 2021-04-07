using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APICoreSample.Models;

namespace APICoreSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmplsController : ControllerBase
    {
        private readonly OrganizationContext _context;
        OrganizationContext db = new OrganizationContext();
        public EmplsController(OrganizationContext context)
        {
            _context = context;
        }

        
        // GET: api/Empls
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Empl>>> GetEmpls()
        {
            return await db.Empls.ToListAsync();
            //return await _context.Empls.ToListAsync();
        }

        // GET: api/Empls/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Empl>> GetEmpl(int id)
        {
            var empl = await _context.Empls.FindAsync(id);

            if (empl == null)
            {
                return NotFound();
            }

            return empl;
        }

        // PUT: api/Empls/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpl(int id, Empl empl)
        {
            if (id != empl.Empid)
            {
                return BadRequest();
            }

            _context.Entry(empl).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmplExists(id))
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

        // POST: api/Empls
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Empl>> PostEmpl(Empl empl)
        {
            _context.Empls.Add(empl);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EmplExists(empl.Empid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEmpl", new { id = empl.Empid }, empl);
        }

        // DELETE: api/Empls/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Empl>> DeleteEmpl(int id)
        {
            var empl = await _context.Empls.FindAsync(id);
            if (empl == null)
            {
                return NotFound();
            }

            _context.Empls.Remove(empl);
            await _context.SaveChangesAsync();

            return empl;
        }

        private bool EmplExists(int id)
        {
            return _context.Empls.Any(e => e.Empid == id);
        }
    }
}
