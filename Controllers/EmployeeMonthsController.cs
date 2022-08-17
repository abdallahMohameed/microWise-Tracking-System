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
    public class EmployeeMonthsController : ControllerBase
    {
        private readonly MicroWiseDbContext _context;

        public EmployeeMonthsController(MicroWiseDbContext context)
        {
            _context = context;
        }

        // GET: api/EmployeeMonths
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeMonth>>> GetEmployeesMonth()
        {
          if (_context.EmployeesMonth == null)
          {
              return NotFound();
          }
            return await _context.EmployeesMonth.ToListAsync();
        }

        // GET: api/EmployeeMonths/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeMonth>> GetEmployeeMonth(int id)
        {
          if (_context.EmployeesMonth == null)
          {
              return NotFound();
          }
            var employeeMonth = await _context.EmployeesMonth.FindAsync(id);

            if (employeeMonth == null)
            {
                return NotFound();
            }

            return employeeMonth;
        }

        // PUT: api/EmployeeMonths/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeMonth(int id, EmployeeMonth employeeMonth)
        {
            if (id != employeeMonth.monthId)
            {
                return BadRequest();
            }

            _context.Entry(employeeMonth).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeMonthExists(id))
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

        // POST: api/EmployeeMonths
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmployeeMonth>> PostEmployeeMonth(EmployeeMonth employeeMonth)
        {
       
            _context.EmployeesMonth.Add(employeeMonth);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EmployeeMonthExists(employeeMonth.monthId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEmployeeMonth", new { id = employeeMonth.monthId }, employeeMonth);
        }

        // DELETE: api/EmployeeMonths/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeMonth(int id)
        {
            if (_context.EmployeesMonth == null)
            {
                return NotFound();
            }
            var employeeMonth = await _context.EmployeesMonth.FindAsync(id);
            if (employeeMonth == null)
            {
                return NotFound();
            }

            _context.EmployeesMonth.Remove(employeeMonth);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeMonthExists(int id)
        {
            return (_context.EmployeesMonth?.Any(e => e.monthId == id)).GetValueOrDefault();
        }
    }
}
