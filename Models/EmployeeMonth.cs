using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace microWise_Tracking_System.Models
{
    public class EmployeeMonth
    {
        [ForeignKey("Month")]
        public int monthId { get; set; }
        [ForeignKey("employee")]
        public int employeeId { get; set; }
        [Required]
        public double adherenceRate { get; set; }
        [Required]
        public string Action { get; set; }
        public string Notes { get; set; }

        public Month Month { get; set; }
        public Employee employee { get; set; }
    }
}
