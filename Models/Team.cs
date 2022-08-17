using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace microWise_Tracking_System.Models
{
    public class Team
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]

        public int? Id { get; set; }
        public string Name { get; set; }
        public int leaderId { get; set; }
        public ICollection<Employee>? members { get; set; }
        public Team()
        {
            members=new HashSet<Employee>();
                
        }

    }
}
