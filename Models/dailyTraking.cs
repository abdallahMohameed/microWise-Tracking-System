using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace microWise_Tracking_System.Models
{
    public class dailyTraking
    {

        public string? date { get; set; }= DateTime.Now.ToString("dd MMMM yyyy");

        [ForeignKey("employee")]

        public int employeeID { get; set; }
        [Required]
        public string status { get; set; }
        [JsonIgnore]
        public Employee? employee { get; set; }
    }
}
