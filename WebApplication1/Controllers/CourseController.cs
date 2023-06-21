using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebApplication1.Models;
using WebApplication1.Repository;
using WebApplication1.ViewModel;

namespace WebApplication1.Controllers
{
    public class CourseController : Controller
    {
        // ITIEntity context = new ITIEntity();
        ICourseRepository icourseRepo;
        IDepatrmentRepository ideptRepo;

      public CourseController(ICourseRepository _courseRepo , IDepatrmentRepository _deptRepo)
        {
            icourseRepo = _courseRepo;
            ideptRepo = _deptRepo;

        }

        public IActionResult Home()
        {
            List<Course> courses = icourseRepo.GetAll();
            return View(courses);
        }
        public IActionResult Index()
        {
            ViewData["DeptList"] = ideptRepo.GetAll();

            return View();
        }

        [HttpPost]
        public IActionResult Save(Course curse)
        {
            //curse.Name != null && curse.Degree >= 30 && curse.minDegree >= 20
            if(ModelState.IsValid == true)
            {
                try
                {
                    //context.courses.Add(curse);
                    //context.SaveChanges();
                    icourseRepo.Insert(curse);
                    icourseRepo.Save();
                    return RedirectToAction("Home");
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("", ex.InnerException.Message);
                }

            }

            ViewData["DeptList"] = ideptRepo.GetAll(); //context.department.ToList();
            ViewData["CourseList"] = icourseRepo.GetAll(); //context.courses.ToList();
            return View("Index", curse);
        }
        [HttpGet]

        public IActionResult Edit(int id)
        {
            Course curse = icourseRepo.GetById(id);  
            //context.courses.FirstOrDefault(i => i.Id == id);
            ViewData["DeptList"] = ideptRepo.GetAll(); 
            //context.department.ToList();
             return View(curse);
        }
        [HttpPost]
        public IActionResult Edit(Course curse, int id)
        {

            if (ModelState.IsValid == true)
            {
                icourseRepo.Update(curse, id);
                icourseRepo.Save();
                return RedirectToAction("Home");
                //Course corse = context.courses.FirstOrDefault(i => i.Id == id);
                //corse.Name = curse.Name;
                //corse.Department = curse.Department;
                //corse.minDegree = curse.minDegree;
                //corse.Degree = curse.Degree;
                //context.SaveChanges();
                //return RedirectToAction("Home");
            }
            ViewData["DeptList"] = ideptRepo.GetAll();//context.department.ToList();
            return View("Edit",curse);
        }
        //public IActionResult Details(int id)
        //{

        // //   Course course = context.courses.SingleOrDefault(c => c.Id == id);
        //   // Instructor instructor = context.instructor.SingleOrDefault(i => i.Id == course.Id);
        //   // Department department = context.department.SingleOrDefault(d => d.Id == course.Dept_id);
        //    InstructorDeptCourseViewModel data = new InstructorDeptCourseViewModel();
        //    data.Id = course.Id;
        //    data.Dept_Name = course.Name;
        //    data.Course_Name = course.Name;
        //    data.Degree = course.Degree;
        //    data.minDegree = course.minDegree;
        //    return View(data);

        //}
        public IActionResult TestDegree(int Degree , int minDegree)
        {
            if (minDegree > Degree)
            {
                return Json(false);
            }
            else 
            {
                return Json(true);
            }
           
        }
        public IActionResult Delete (int id)
        {
            //Course course = context.courses.FirstOrDefault(e => e.Id == id);
            icourseRepo.Delete(id);
            icourseRepo.Save();
            return RedirectToAction("Home");
            //if(course == null)
            //{
            //    return Content("not found");
            //}
            //else
            //{
            //    context.courses.Remove(course);
            //    context.SaveChanges();
            //    return RedirectToAction("Home");
            //}
           
        }
    
    }
}
