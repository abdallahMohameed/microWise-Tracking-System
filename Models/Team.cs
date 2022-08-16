using System.ComponentModel.DataAnnotations.Schema;

namespace microWise_Tracking_System.Models
{
    public class Team
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("Employee")]
        public int leaderId { get; set; }

        public Employee Employee { get; set; }
    }
}
