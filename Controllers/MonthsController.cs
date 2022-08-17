using System;
using System.Collections.Generic;
using System.Globalization;
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
    public class MonthsController : ControllerBase
    {
        private readonly MicroWiseDbContext _context;

        public MonthsController(MicroWiseDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Month>>> Getmonths()
        {
             return await _context.months.ToListAsync();
        }


        [HttpPost]
        public async Task<ActionResult<Month>> PostMonth(Month month)
        {
            var DataBaseMonth = _context.months.Where(a => a.date == month.date).FirstOrDefault();
            if(DataBaseMonth == null)
            {
                string date = month.date;
                string[] dateSplited = date.Split(' ');
                int monthNumber = DateTime.ParseExact(dateSplited[0], "MMMM", CultureInfo.CurrentCulture).Month;

                int year = int.Parse(dateSplited[1]);
                int daysInMonth = 0;
                int days = DateTime.DaysInMonth(year, monthNumber);
                for (int i = 1; i <= days; i++)
                {
                    DateTime day = new DateTime(year, monthNumber, i);
                    if (day.DayOfWeek != DayOfWeek.Sunday && day.DayOfWeek != DayOfWeek.Saturday)
                    {
                        daysInMonth++;
                    }
                }
                month.BusinessDays = daysInMonth;
                _context.months.Add(month);
                await _context.SaveChangesAsync();

                return Ok();
            }
            return BadRequest("This Month Already Created");
        }

    }
}
