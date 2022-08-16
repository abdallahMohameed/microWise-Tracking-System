using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace microWise_Tracking_System.Models
{
    public class Month
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string? date { get; set; } = DateTime.Now.ToString("yyyy MMMM");

        public int BusinessDays { get; set; }

        public int daysInMonth { get; set; }




    }
}
