using lab2.Data;
using lab2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace lab2.Controllers
{
    public class PostController : Controller
    {
        private AppDbContext _context;

        public PostController(AppDbContext context)
        {
            _context = context;
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Post post)
        {

            post.Date = DateTime.Now;
            post.BlogId = (int)HttpContext.Session.GetInt32("BlogId");
            post.Author = HttpContext.Session.GetString("Username");

            _context.Posts.Add(post);
            _context.SaveChanges();

            return RedirectToAction("Index", "Blog");
        }

        public ActionResult Index(int id)
        {
            HttpContext.Session.SetInt32("BlogId", id);

            var posts = _context.Posts.Where(u => u.BlogId == id).ToList();

            return View(posts);
        }

        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int? id)
        {
            if (id == null) return NotFound();

            var post = _context.Posts.SingleOrDefault(u => u.Id == id);

            if (post == null) return NotFound();

            _context.Posts.Remove(post);
            _context.SaveChanges();

            return RedirectToAction("Index", "Blog");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null) return NotFound();

            var posts = _context.Posts.SingleOrDefault(u => u.Id == id);

            if(posts == null) return NotFound();

            return View("Create", posts);
        }
    }
}
