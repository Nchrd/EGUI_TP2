using lab2.Data;
using lab2.Data.ViewModel;
using lab2.Models;
using Microsoft.AspNetCore.Mvc;

namespace lab2.Controllers
{
    public class AccountController : Controller
    {
        private AppDbContext _context;

        public AccountController(AppDbContext context)
        {
            _context = context;
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            if(!ModelState.IsValid) return View("Register", user);

            if(_context.Users.Where(x => x.Email == user.Email).Any())
            {
                ModelState.AddModelError("Email", "Email already taken");
                return View("Register", user);
            }

            if (_context.Users.Where(x => x.Username == user.Username).Any())
            {
                ModelState.AddModelError("Username", "Username already taken");
                return View("Register", user);
            }

            _context.Users.Add(user);
            _context.SaveChanges();

            HttpContext.Session.SetString("Username", user.Username);
            HttpContext.Session.SetInt32("UserId", user.Id);

            return View("Index", "Blog");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel loginVM)
        {
            if(!ModelState.IsValid) return View("Login", loginVM);

            var loginUser = _context.Users.Where(u => u.Username == loginVM.Username && u.Password == loginVM.Password).FirstOrDefault();
            if(loginUser == null)
            {
                ModelState.AddModelError("Username", "Wrong identifiers, please try again");
                return View("Login", loginVM);
            }
            else
            {
                HttpContext.Session.SetString("Username", loginUser.Username);
                HttpContext.Session.SetInt32("UserId", loginUser.Id);
                return RedirectToAction("Index", "Blog");
            }
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Login");
        }
    }
}
