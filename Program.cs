using EntityFramework.Data;
using EntityFramework.Models;

namespace EntityFramework
{
    public class Program
    {
        static void Main()
        {
            using var context = new BlogDataContext();
            var user = new User
            {
                Name = "Rafael",
                Email = "rafael@gmail.com",
                Bio = "Desenvolvedor",
                Image = "https://github.com/rafael-santos-dev.png",
                PasswordHash = "123456",
                Slug = "rafael-santos-dev"
            };
            var category = new Category

            {
                Name = "Backend",
                Slug = "backend"
            };
            var post = new Post
            {
                Author = user,
                Category = category,
                Title = "ASP.NET",
                Summary = "ASP.NET é um framework",
                Body = "ASP.NET é um framework",
                Slug = "aspnet",
                CreateDate = DateTime.Now,
                LastUpdateDate = DateTime.Now
            };
            context.Posts.Add(post);
            //context.SaveChanges();
        }
    }
}

