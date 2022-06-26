using daily_blog.Models;
using Microsoft.EntityFrameworkCore;

namespace daily_blog.Services
{
    public class PostService
    {
        private CoreDbContext context;
        private readonly CoreDbContext? _context;
        private readonly DbSet<PostModel> _dbSet;
        public PostService()
        {
            _context = new CoreDbContext();
            _dbSet = _context.Set<PostModel>();
        }
        public void add(PostModel post)
        {
            _dbSet.Add(post);
            _context.SaveChanges();
        }

        public void delete(int id)
        {
            var post = _dbSet.Find(id);
            _dbSet.Remove(post);
        }

        public PostModel? getById(int id)
        {
            PostModel post = _dbSet.Include(p => p.Author).FirstOrDefault(p => p.Id == id);
            // PostModel post = _dbSet.Find(id);
            return post;
        }

        public PostModel[] getAll()
        {
            PostModel[] posts = _dbSet.ToArray();
            return posts;
        }
    }
}
