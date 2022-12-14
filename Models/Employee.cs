using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace microWise_Tracking_System.Models
{
    public class Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]

        public int? Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]

        public string? startDate { get; set; }  = DateTime.Now.ToString("dd MMMM yyyy");
        public string Role { get; set; }
        [ForeignKey("team")]
        public int teamId { get; set; }
        [JsonIgnore]
        public Team? team { get; set; }
    }
}
