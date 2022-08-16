using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace microWise_Tracking_System.Models
{
    public class dailyTraking
    {
        public string? date { get; set; }= DateTime.Now.ToString("yyyy MMMM");

        [ForeignKey("employee")]

        public int employeeID { get; set; }
        [Required]
        public string status { get; set; }

        public Employee employee { get; set; }
    }
}
