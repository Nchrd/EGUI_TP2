using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using lab2.Models;
using static DataLibrary.BusinessLogic.UserProcessor;

namespace lab2.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public IActionResult SignUp()
    {
        ViewBag.Message = "User sign up";
        return View();
    }

    public IActionResult Login()
    {
        ViewBag.Message = "User login";
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]  
    public ActionResult SignUp(UserModel model)
    {
        if (ModelState.IsValid)
        {
            int recordsCreated = CreateUser(model.Username, model.Password, model.Mail);
            return RedirectToAction("MainMenu", "Dashboard");
        }
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Login(UserModel model)
    {
        if (ModelState.IsValid)
        {
            
            return RedirectToAction("MainMenu", "Dashboard");
        }
        return View();
    }
    

}
