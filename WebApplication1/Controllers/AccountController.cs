using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApplication1.Models;
using WebApplication1.Repository;
using WebApplication1.ViewModel;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        IAcouuntRepository account;
        public AccountController(IAcouuntRepository accRepo)
        {
            account = accRepo;

        }
        [HttpGet]
        public IActionResult Register()
        {
            
            return View();
        }
        // /Account/Register
        [HttpPost]
        public IActionResult Register(AccountViewModel accvm)
        {
            if (ModelState.IsValid)
            {
                Account acc = new Account();

                acc.username = accvm.username;
                acc.password = accvm.password;

                ClaimsIdentity claims = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                claims.AddClaim(new Claim(ClaimTypes.Name, acc.username));
                claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, acc.id.ToString()));


                ClaimsPrincipal principal = new ClaimsPrincipal(claims);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return Content("ok");

            }
            return View(accvm);
        }

        public ActionResult logIn() { 
            return View();
        }
        [HttpPost]
        public ActionResult logIn(Account _acc)
        {
            if (account.find(_acc.username , _acc.password))
            {
                Account acc = new Account();

                acc.username = _acc.username;
                acc.password = _acc.password;

                ClaimsIdentity claims = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                claims.AddClaim(new Claim(ClaimTypes.Name, acc.username));
                claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, acc.id.ToString()));


                ClaimsPrincipal principal = new ClaimsPrincipal(claims);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return Content("login");
            }
            return View(_acc);
        }



    }
}
