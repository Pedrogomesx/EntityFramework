using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.Data
{
    public class DbCRUD
    {

        public static void DbQueryByName(string name)
        {
            using var context = new BlogDataContext();
            //Where antes do ToList para que ele filtre e aloque o resultado na memória antes de alocar todos os dados na lista
            //AsNoTracking somente para leitura no banco
            var tags = context
                .Tags
                .AsNoTracking()
                .Where(x => x.Name.Contains(name))
                .ToList();
            foreach (var item in tags)
            {
                Console.WriteLine(item.Name);
            }
        }

        public static void DbDeleteTag(int id)
        {
            using var context = new BlogDataContext();
            var tag = context.Tags.FirstOrDefault(x => x.Id == id) ?? throw new Exception("Tag não encontrada");
            context.Remove(tag);
            context.SaveChanges();

        }

        public static void DbCreatetag(string name, string slug)
        {
            using var context = new BlogDataContext();
            var tag = new Tag
            {
                Name = name,
                Slug = slug
            };
            context.Tags.Add(tag);
            context.SaveChanges();

        }

        public static void DbUpdateTag(int id, string name)
        {
            using var context = new BlogDataContext();
            var tag = context.Tags.FirstOrDefault(x => x.Id == id) ?? throw new Exception("Tag não encontrada");
            tag.Name = name;
            context.SaveChanges();
            //Console.WriteLine($"Antes do update\nTag Name: {tag.Name}");
            //Console.WriteLine($"Depois do update\nTag Name: {tag.Name}");
        }
        public static void DbSelectTag(int id)
        {
            using var context = new BlogDataContext();
            var tag = context.Tags.AsNoTracking().FirstOrDefault(x => x.Id == id) ?? throw new Exception("Tag não encontrada");
            Console.WriteLine($"Tag Name: {tag?.Name}");

        }
    }
}
