using lab2.Data;
using lab2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;


namespace lab2.Controllers
{
    public class BlogController : Controller
    {
        private AppDbContext _context;

        public BlogController(AppDbContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            var blogs = _context.Blogs.ToList();

            return View(blogs);
        }

        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [Route("Blog/Create")]
        public ActionResult Create(Blog blog)
        {
            if(!ModelState.IsValid) return View("Create", blog);

            blog.UserId = (int)HttpContext.Session.GetInt32("UserId");
            blog.Author = HttpContext.Session.GetString("Username");

            _context.Blogs.Add(blog);
            _context.SaveChanges();

            return RedirectToAction("Index", "Blog");
        }

        public ActionResult Delete(int id)
        {
            if (id <= 0) return NotFound();

            var blog = _context.Blogs.Where(u => u.Id == id).FirstOrDefault();

            _context.Blogs.Remove(blog);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
