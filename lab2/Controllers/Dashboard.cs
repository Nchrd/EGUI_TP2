using Microsoft.AspNetCore.Mvc;

namespace lab2.Controllers
{
    public class Dashboard : Controller
    {
        public IActionResult MainMenu()
        {
            return View();
        }
    }
}
