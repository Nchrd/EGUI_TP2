using lab2.Data.Services;
using lab2.Models;
using Microsoft.AspNetCore.Mvc;

namespace lab2.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _service;

        public BlogController(IBlogService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Title")]BlogModel blog)
        {
            if (!ModelState.IsValid)
            {
                return View(blog);
            }

            await _service.AddAsync(blog);
            return await Task.FromResult(RedirectToAction("Index"));
        }
    }
}
