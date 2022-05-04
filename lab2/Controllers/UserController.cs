using lab2.Data;
using lab2.Data.Services;
using lab2.Data.Static;
using lab2.Data.ViewModels;
using lab2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace lab2.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _service;
        private readonly UserManager<UserModel> _userManager;
        private readonly SignInManager<UserModel> _signInManager;
        private readonly AppDbContext _context;

        public UserController(IUserService service, UserManager<UserModel> userManager, SignInManager<UserModel> signInManager, AppDbContext context)
        {
            _service = service;
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        public IActionResult Login() => View(new LoginVm());

        [HttpPost]
        public IActionResult Login(LoginVm loginVm)
        {
            if (!ModelState.IsValid)
            {
                return View(loginVm);
            }

            var user = _context.Users.Where(u => u.Mail == loginVm.Mail && u.Password == loginVm.Password).FirstOrDefault();
            if(user != null)
            {
                HttpContext.Session.SetString("user", JsonConvert.SerializeObject(user));

                return RedirectToAction("Index", "Blog");
            }
            TempData["Error"] = "Wrong credentials, please try again";
            return View(loginVm);
        }

        public IActionResult Register() => View(new RegisterVm());

        [HttpPost]
        public IActionResult Register(RegisterVm registerVm)
        {
            if(!ModelState.IsValid) return View(registerVm);

            if (_context.Users.Where(u => u.Mail == registerVm.Mail).Any())
            {
                TempData["Error"] = "This email is already taken !";
                return View(registerVm);
            }

            if (_context.Users.Where(u => u.Username == registerVm.Username).Any())
            {
                TempData["Error"] = "This username is already taken !";
                return View(registerVm);
            }

            var newUser = new UserModel()
            {
                Username = registerVm.Username,
                Email = registerVm.Mail,
                Password = registerVm.Password
            };

            _context.Users.Add(newUser);
            _context.SaveChanges();
            _userManager.AddToRoleAsync(newUser, UserRole.User);
            HttpContext.Session.SetString("user", JsonConvert.SerializeObject(newUser));

            return View("RegisterCompleted");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Blog");
        }

        public IActionResult AccesDenied(string ReturnUrl)
        {
            return View();
        }
    }
}
