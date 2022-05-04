using Microsoft.EntityFrameworkCore;
using lab2.Models;
using Microsoft.Data.SqlClient;

namespace lab2.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<BlogModel> Blogs { get; set; }
        public DbSet<PostModel> Posts { get; set; }
    }
}
