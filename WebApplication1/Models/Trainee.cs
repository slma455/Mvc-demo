using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Trainee
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }
        public string? Address { get; set; }
        public int Grade { get; set; }
        [ForeignKey("Department")]
        public int Dept_id { get; set; }
        public virtual Department? Department { get; set; }
        public virtual List<crsCourse>? crs { get; set; }
        

    }
}
