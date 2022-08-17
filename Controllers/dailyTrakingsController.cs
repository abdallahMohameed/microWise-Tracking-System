using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using microWise_Tracking_System.Models;

namespace microWise_Tracking_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class dailyTrakingsController : ControllerBase
    {
        private readonly MicroWiseDbContext _context;

        public dailyTrakingsController(MicroWiseDbContext context)
        {
            _context = context;
        }

        // PUT: api/dailyTrakings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutdailyTraking(int id, dailyTraking dailyTraking)
        {
            if (id != dailyTraking.employeeID)
            {
                return BadRequest();
            }

            _context.Entry(dailyTraking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!dailyTrakingExists(id))
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

        // POST: api/dailyTrakings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<dailyTraking>> PostdailyTraking(dailyTraking dailyTraking)
        {
          if (_context.DailyTraking == null)
          {
              return Problem("Entity set 'MicroWiseDbContext.DailyTraking'  is null.");
          }
            _context.DailyTraking.Add(dailyTraking);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (dailyTrakingExists(dailyTraking.employeeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetdailyTraking", new { id = dailyTraking.employeeID }, dailyTraking);
        }

        // DELETE: api/dailyTrakings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletedailyTraking(int id)
        {
            if (_context.DailyTraking == null)
            {
                return NotFound();
            }
            var dailyTraking = await _context.DailyTraking.FindAsync(id);
            if (dailyTraking == null)
            {
                return NotFound();
            }

            _context.DailyTraking.Remove(dailyTraking);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool dailyTrakingExists(int id)
        {
            return (_context.DailyTraking?.Any(e => e.employeeID == id)).GetValueOrDefault();
        }
    }
}
