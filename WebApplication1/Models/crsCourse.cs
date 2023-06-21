using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class crsCourse
    {
        public int Id { get; set; }
        public int Degree { get; set;}

        [ForeignKey("Course")]
        public int Crs_id { get; set; }

        [ForeignKey("Trainee")]
        public int Trainee_id { get; set; }

        public virtual Course? Course { get; set; }
        public virtual Trainee? Trainee { get; set; }



    }
}
