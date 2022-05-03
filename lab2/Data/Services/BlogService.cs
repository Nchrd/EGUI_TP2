using lab2.Data.Base;
using lab2.Models;

namespace lab2.Data.Services
{
    public class BlogService:EntityBaseRepository<BlogModel>, IBlogService
    {
        public BlogService(AppDbContext context) : base(context)
        {

        }
    }
}
