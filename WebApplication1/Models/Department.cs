namespace WebApplication1.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Manger { get; set; }

       public virtual List<Instructor>? Instructors { get; set; }
       public virtual  List<Trainee>? Trainees { get; set; }
       
        public virtual List<Course>? Course { get; set; }
       
    }
}
