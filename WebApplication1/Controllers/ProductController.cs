using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {

        public IActionResult GetAll()
        {
            List<Product> products = ProductList.GetAll();
            return View("Allproduct", products);
        }
        public IActionResult Details(int id)
        {
            //model
            Product products =   ProductList.Find(id);
            
            //send to view
            return View("Details" , products);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
