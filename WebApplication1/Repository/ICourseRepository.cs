using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public interface ICourseRepository
    {
        List<Course> GetAll();
        Course GetById(int id);
        void Insert(Course course);
        void Update(Course course, int id);
        void Delete(int id);
        void Save();

    }
}
