using WebApplication1.Models;
namespace WebApplication1.ViewModel
{
    public class InstructorDeptCourseViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
        public int Degree { get; set; }

        public int minDegree { get; set; }


        public List<Department> Departments { get; set; }
        public int Dept_Id { get; set; }
        public string? Dept_Name { get; set; }
        public List<Course> Courses { get; set; }
        public string Course_Name { get; set; }
        public int Course_id {
            get;set;
        }
        public List<Instructor> instructors { get; set; }
    }
}
