using WebApplication1.Models;

namespace WebApplication1.ViewModel
{
    public class TraineeCourseColor
    {
        public string Color { get; set; }
        public int crs_Id { get; set; }
        public int trainee_Id { get; set; }
        public string crs_name { get; set; }
        public int minDegree { get; set; }
        public string trainee_name { get; set; }
        public int degree { get; set; }
        public List<Course> crs { get; set; }
        


    }
}
