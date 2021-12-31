using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CafeController : ControllerBase
    {
        private readonly OdeToFoodDbContext _context;

        public CafeController(OdeToFoodDbContext context)
        {
            _context = context;
        }

        // GET: api/Cafe
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cafe>>> GetCafes()
        {
            return await _context.Cafes.ToListAsync();
        }

        // GET: api/Cafe/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cafe>> GetCafe(int id)
        {
            var cafe = await _context.Cafes.FindAsync(id);

            if (cafe == null)
            {
                return NotFound();
            }

            return cafe;
        }

        // PUT: api/Cafe/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCafe(int id, Cafe cafe)
        {
            if (id != cafe.Id)
            {
                return BadRequest();
            }

            _context.Entry(cafe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CafeExists(id))
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

        // POST: api/Cafe
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cafe>> PostCafe(Cafe cafe)
        {
            _context.Cafes.Add(cafe);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCafe", new { id = cafe.Id }, cafe);
        }

        // DELETE: api/Cafe/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCafe(int id)
        {
            var cafe = await _context.Cafes.FindAsync(id);
            if (cafe == null)
            {
                return NotFound();
            }

            _context.Cafes.Remove(cafe);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CafeExists(int id)
        {
            return _context.Cafes.Any(e => e.Id == id);
        }
    }
}
