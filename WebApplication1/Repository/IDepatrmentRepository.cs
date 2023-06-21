using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public interface IDepatrmentRepository
    {
        List<Department> GetAll();
        Department GetById(int id);
        void Insert(Department dept);
        void Update(int id, Department dept);
        void Delete(int id);
        void Save();
    }
}
