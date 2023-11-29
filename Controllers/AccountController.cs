using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using QuanLy_ShopConCung.Data;
using QuanLy_ShopConCung.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace QuanLy_ShopConCung.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(User _userFromPage)
        {
            var _user = _context?.User?.Where(m=>m.UserEmail == _userFromPage.UserEmail && m.UserPassword == _userFromPage.UserPassword).FirstOrDefault()  ;
            if (_user == null)
            {
                ViewBag.LoginStatus = 0;
              
            }
            else
            {
                var claims = new List<Claim>
                {
                new Claim(ClaimTypes.Name, _user.UserEmail ),
                new Claim("FullName", _user.UserName ),
                new Claim(ClaimTypes.Role, _user.UserRole ),
                };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                 
                };

                HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                return RedirectToAction("Index", "Account");
                //return RedirectToAction("Index", "Admin");
            }
            return View();
        }
        public IActionResult Logout()
        {
			HttpContext.Session.Clear();
			HttpContext.SignOutAsync(
            CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }




        //Dang ki

       

    }
}
