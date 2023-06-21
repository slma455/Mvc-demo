using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.ViewModel;

namespace WebApplication1.Controllers
{
    public class InstructorController : Controller
    {
        ITIEntity context = new ITIEntity();
        public IActionResult showCourse(int deptId)
        {
   var courses = context.courses.Where(c => c.Dept_id == deptId).Select(c => new  { id= c.Id, name =c.Name}).ToList();
            return Json(courses);
        }
        public IActionResult Index()
        {
            List<Instructor> instructorsModel = context.instructor.ToList();
          
            return View(instructorsModel);
        }
        public IActionResult New()
        {
            ViewData["DeptList"] = context.department.ToList();
            ViewData["CourseList"] = context.courses.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Save(Instructor inst)
        {
            if(inst.Name != null && inst.Salary >=3000 && inst.Address != null )
            {
                context.instructor.Add(inst);
              
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            ViewData["DeptList"] = context.department.ToList();
            ViewData["CourseList"] = context.courses.ToList();
            return View("New", inst);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Instructor ins = context.instructor.FirstOrDefault(i => i.Id == id);
            ViewData["CourseList"] = context.courses.ToList();
            ViewData["DeptList"] = context.department.ToList();
            return View(ins);
        }

        //[HttpPost]
        //public ActionResult Search(string Searchby, string search)
        //{
        //    if (Searchby == "Name")
        //    {
        //        var model = context.instructor.Where(ins => ins.Name == search || search == null).ToList();
        //        return View(model);

        //    }
        //    else
        //    {
        //        var model = context.instructor.Where(ins => ins.Name.StartsWith(search) || search == null).ToList();
        //        return View(model);
        //    }
        //}


            [HttpPost]
        public IActionResult Edit(Instructor ins , int id)
        {
            
            if(ins.Name != null)
            {
                Instructor instr = context.instructor.FirstOrDefault(i => i.Id == ins.Id);
                instr.Name = ins.Name;
                instr.Address = ins.Address;
                instr.Salary = ins.Salary;
                instr.Crs_id = ins.Crs_id;
                instr.Dept_id = ins.Dept_id;
                instr.Image = ins.Image;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["CourseList"] = context.courses.ToList();
            ViewData["DeptList"] = context.department.ToList();
            return View("Edit");

        }
        public IActionResult Search(string name)
        {
            if(name != "")
            {
                var inst = context.instructor.Where(n => n.Name.ToLower().Contains(name.ToLower())).ToList();
                return View("Index", inst);
            }
            else
            {
                var instructor = context.instructor.ToList();
                return View("Index", instructor);
            }
        }

        public IActionResult Details(int id)
        {
            Instructor instructor = context.instructor.SingleOrDefault(i => i.Id == id);
            Department department = context.department.SingleOrDefault(d => d.Id == instructor.Dept_id);
            Course course = context.courses.SingleOrDefault(c => c.Id == instructor.Crs_id);
            InstructorDeptCourseViewModel data = new InstructorDeptCourseViewModel();
            data.Id = instructor.Id;
            data.Name = instructor.Name;
            data.Salary = instructor.Salary;
            data.Address = instructor.Address;
            data.Image = instructor.Image;
            data.Dept_Name = department.Name;
            data.Course_Name = course.Name;
            return View(data);

        }
    }
}
