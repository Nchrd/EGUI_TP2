using lab2.Models;

namespace lab2.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder) 
        {
            using(var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //Users
                if (!context.Users.Any())
                {
                    context.Users.AddRange(new List<UserModel>()
                    {
                        new UserModel()
                        {
                            Username = "UserTest1",
                            Password = "PasswordTest1",
                            Mail = "mail1@test.com"
                        },
                        new UserModel()
                        {
                            Username = "UserTest2",
                            Password = "PasswordTest2",
                            Mail = "mail2@test.com"
                        }
                    });
                    context.SaveChanges();
                }
                //Blogs
                if (!context.Blogs.Any())
                {
                    context.Blogs.AddRange(new List<BlogModel>()
                    {
                        new BlogModel()
                        {
                            Title = "Blog Test 1",
                            BlogId = 1,
                            UserId = 1

                        },
                        new BlogModel()
                        {
                            Title = "Blog Test 2",
                            BlogId = 2,
                            UserId = 2
                        }
                    });
                    context.SaveChanges();
                }
                //Posts
                if (!context.Posts.Any())
                {
                    context.Posts.AddRange(new List<PostModel>()
                    {
                        new PostModel()
                        {
                            Title = "Post Test 1",
                            BlogId = 1,
                            Content = "Conten of post 1",
                            Date = DateTime.Now

                        },
                        new PostModel()
                        {
                            Title = "Post Test 2",
                            BlogId = 2,
                            Content = "Content of post 2",
                            Date = DateTime.Now
                        }
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
