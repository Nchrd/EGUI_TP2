using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using lab2.Models;
using static DataLibrary.BusinessLogic.BlogProcessor;

namespace lab2.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult MainMenu()
        {
            return View();
        }

        public IActionResult CreateBlog()
        {
            return View();
        }

        public IActionResult BlogList()
        {
            ViewBag.Message = "List of blogs";

            return View();
        }
    }
}
