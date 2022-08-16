using System.ComponentModel.DataAnnotations.Schema;

namespace microWise_Tracking_System.Models
{
    public class Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateOnly startDate { get; set; }  = DateOnly.FromDateTime(DateTime.Now);

        [ForeignKey("Team")]

        public int teamId { get; set; }
        public string Role { get; set; }

        public Team Team { get; set; }
    }
}
