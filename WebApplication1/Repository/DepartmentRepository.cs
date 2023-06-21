using NuGet.Protocol;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class DepartmentRepository : IDepatrmentRepository
    {
        ITIEntity context;
         public DepartmentRepository(ITIEntity iTIEntity)
        {
            context =iTIEntity;
        }
        public List<Department> GetAll()
        {
            return context.department.ToList();
        }
        public Department GetById(int id)
        {
            return context.department.FirstOrDefault(d => d.Id == id);
        }
        public void Insert(Department dept)
        {
            context.department.Add(dept);
        }
        public void Update(int id , Department dept)
        {
            //get old reference 
            Department oldDept = GetById(id);
            //change 
            oldDept.Name = dept.Name;
            oldDept.Manger = dept.Manger;
        }
        public void Delete(int id)
        {
            Department oldDept = GetById(id);
            //hard delete
            context.department.Remove(oldDept);
        }
        public void Save()
        {
            context.SaveChanges();
        }
    }
}
