using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace microWise_Tracking_System.Models
{
    public class dailyTraking
    {
        public DateOnly date { get; set; }= DateOnly.FromDateTime(DateTime.Now);

        [ForeignKey("employee")]

        public int employeeID { get; set; }
        [Required]
        public string status { get; set; }

        public Employee employee { get; set; }
    }
}
