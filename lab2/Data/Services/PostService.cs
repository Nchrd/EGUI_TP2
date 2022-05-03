using lab2.Data.Base;
using lab2.Models;
using Microsoft.EntityFrameworkCore;

namespace lab2.Data.Services
{
    public class PostService: EntityBaseRepository<PostModel>, IPostService
    {
    }
}
