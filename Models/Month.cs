using System.ComponentModel.DataAnnotations.Schema;

namespace microWise_Tracking_System.Models
{
    public class Month
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public DateOnly date { get; set; }= DateOnly.FromDateTime(DateTime.Now);
        public int BusinessDays { get; set; }

        [NotMapped]
        public int daysInMonth { get; set; }




    }
}
