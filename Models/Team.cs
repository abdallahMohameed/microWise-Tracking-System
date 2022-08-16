using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace microWise_Tracking_System.Models
{
    public class Team
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }
        public string Name { get; set; }
        public int leaderId { get; set; }
 
        public ICollection<Employee> members { get; set; }
        public Team()
        {
            members=new HashSet<Employee>();
                
        }

    }
}
