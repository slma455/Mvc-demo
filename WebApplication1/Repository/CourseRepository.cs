using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class CourseRepository : ICourseRepository
    {
        ITIEntity context;
        public CourseRepository(ITIEntity iTIEntity)
        {
         context =   iTIEntity;
        }
        public List<Course> GetAll()
        {
            return context.courses.ToList();
        }
        public Course GetById(int id)
        {
            return context.courses.FirstOrDefault(d => d.Id == id);
        }
        public void Insert (Course course)
        {
            context.courses.Add(course);
        }
        public void Save()
        {
            context.SaveChanges();
        }
        public void Update(Course course , int id)
        {
            //get old refrence
            Course oldCourse = GetById(id);
            //change
            oldCourse.Name = course.Name;
            oldCourse.Degree = course.Degree;
            oldCourse.minDegree = course.minDegree;
            oldCourse.Dept_id = course.Dept_id;
        }
        public void Delete (int id)
        {
            Course oldCourse = GetById(id);
            context.courses.Remove(oldCourse);
        }

     
    }
}
