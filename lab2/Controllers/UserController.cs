using lab2.Data;
using lab2.Data.Services;
using lab2.Data.Static;
using lab2.Data.ViewModels;
using lab2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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

        public IActionResult Index()
        {
            var data = _service.GetAll();
            return View(data);
        }

        public IActionResult login() => View(new LoginVm());

        [HttpPost]
        public async Task<IActionResult> Login(LoginVm loginVm)
        {
            if (!ModelState.IsValid)
            {
                return View(loginVm);
            }

            var user = await _userManager.FindByEmailAsync(loginVm.Mail);
            if(user != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginVm.Password);
                if (passwordCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginVm.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Blog");
                    }
                }
                TempData["Error"] = "Wrong credentials, please try again";
                return View(loginVm);
            }
            TempData["Error"] = "Wrong credentials, please try again";
            return View(loginVm);
        }

        public IActionResult Register() => View(new RegisterVm());

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVm registerVm)
        {
            if(!ModelState.IsValid) return View(registerVm);

            var user = await _userManager.FindByEmailAsync(registerVm.Mail);
            if(user != null)
            {
                TempData["Error"] = "This email is already taken !";
                return View(registerVm);
            }

            user = await _userManager.FindByNameAsync(registerVm.Username);
            if(user != null)
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

            var newUserReponse = await _userManager.CreateAsync(newUser, registerVm.Password);

            if (newUserReponse.Succeeded) await _userManager.AddToRoleAsync(newUser, UserRole.User);

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
