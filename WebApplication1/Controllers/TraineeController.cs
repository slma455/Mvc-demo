using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using WebApplication1.Models;
using WebApplication1.ViewModel;

namespace WebApplication1.Controllers
{
    public class TraineeController : Controller
    {
        ITIEntity context = new ITIEntity();
        // /Trainee/Index
        public IActionResult Index()
        {
            List<Trainee> trainees = context.trainee.ToList();
            return View("view", trainees);
        }
        public IActionResult Details(int id)
        {
            //  Trainee trainees = context.trainee.FirstOrDefault(t=>t.Id == id);
            // crsCourse src = context.crsCourses.Where(s=>s.Trainee_id==trainees.Id).ToList();
            // List<Course> crs = context.courses.Where(c => c.Id == src.Crs_id).ToList();
            //  List<crsCourse> 


            //    TraineeCourseColor tcc = new TraineeCourseColor();

            //    tcc.degree = src.Degree;
            //    tcc.trainee_Id = trainees.Id;
            //    tcc.trainee_name = trainees.Name;
            //    tcc.crs = crs;

            //    foreach (var item in crs)
            //    {
            //        tcc.crs_name = item.Name;

            //    if (tcc.degree <= item.minDegree)
            //    {
            //        tcc.Color = "Red";

            //    }
            //    else tcc.Color = "Green";
            //    };
            return View("Details");
        }
        public IActionResult showResult(int tid, int cid)
        {
            Course crs = context.courses.FirstOrDefault(c => c.Id == cid);
            Trainee tn = context.trainee.FirstOrDefault(t => t.Id == tid);
            crsCourse src = context.crsCourses.FirstOrDefault(s => s.Crs_id == cid && s.Trainee_id == tid);
            TraineeCourseColor tcc = new TraineeCourseColor();
            tcc.crs_Id = crs.Id;
            tcc.degree = src.Degree;
            tcc.trainee_Id = tn.Id;
            tcc.trainee_name = tn.Name;
            tcc.crs_name = crs.Name;
            if (tcc.degree <= crs.minDegree)
            {
                tcc.Color = "Red";
            }
            else
            {
                tcc.Color = "Green";
            };
            return View(tcc);

        }


        // /Trainee/showCourse/7
        public IActionResult showCourse(int id)
        {
            List<crsCourse> courseResults = context.crsCourses.Include(c => c.Course).Include(c => c.Trainee).Where(c => c.Course.Id == id).ToList();
            List<TraineeCourseColor> list = new List<TraineeCourseColor>();
            foreach(var item in courseResults)
            {
                list.Add(new TraineeCourseColor
                {
                    degree = item.Degree,
                    crs_name = item.Course.Name,
                    trainee_name = item.Trainee.Name,
              
                });
            }
            return View(list);
        }
        public IActionResult showTrainee(int id)
        {

            List<crsCourse> courseResults = context.crsCourses.ToList();
            List<Course> courses = context.courses.ToList();
            List<Trainee> trainees = context.trainee.ToList();
            var TCourses = (from courseResult in courseResults
                            join course in courses on courseResult.Id equals course.Id
                            join trianee in trainees on courseResult.Trainee_id equals trianee.Id
                            where trianee.Id == id
                            select new TraineeCourseColor
                            {
                                trainee_name = trianee.Name,
                                crs_name = course.Name,
                                Color = course.minDegree > courseResult.Degree ? "Red" : "green"
                            }).ToList();
            return View(TCourses);
        }





        //}
    }
}
