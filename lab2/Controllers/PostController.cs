using lab2.Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace lab2.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService _service;

        public PostController(IPostService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }
    }
}
