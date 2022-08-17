using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace microWise_Tracking_System.Models
{
    public class Month
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public int? id { get; set; }
        public string? date { get; set; } = DateTime.Now.ToString("MMMM yyyy");

        public int BusinessDays { get; set; }
        [JsonIgnore]

        public int? daysInMonth { get; set; }




    }
}
