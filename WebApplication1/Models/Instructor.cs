using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Instructor
    {
      
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Salary { get; set; }
        public string? Image { get; set; }

        public string? Address { get; set; }
        [ForeignKey("Department")]
        public int Dept_id { get; set; }
        [ForeignKey("Course")]
        public int Crs_id { get; set; }
        public virtual Department? Department { get; set; }
        public virtual Course? Course { get; set; }

    }
}
