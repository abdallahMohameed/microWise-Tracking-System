using System.ComponentModel.DataAnnotations.Schema;

namespace microWise_Tracking_System.Models
{
    public class EmployeeMonth
    {
        [ForeignKey("Month")]
        public int monthId { get; set; }
        [ForeignKey("employee")]
        public int employeeId { get; set; }
        public double adherenceRate { get; set; }
        public string Action { get; set; }
        public string Notes { get; set; }

        public Month Month { get; set; }
        public Employee employee { get; set; }
    }
}
