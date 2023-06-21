using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class StateController : Controller
    {

        public IActionResult setSession(string name)
        {

            HttpContext.Session.SetString("Name", name);
            HttpContext.Session.SetInt32("Age", 23);
            return Content("session saved");
        }
        public IActionResult getSession()
        {
            string n = HttpContext.Session.GetString("Name");
            int s = HttpContext.Session.GetInt32("Age").Value;
            return Content($"name ={n}\t age={s}");

        }
    }
}
