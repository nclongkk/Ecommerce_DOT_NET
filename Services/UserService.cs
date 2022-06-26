using daily_blog.Models;
using Microsoft.EntityFrameworkCore;

namespace daily_blog.Services
{
    public class UserService
    {
        private CoreDbContext context;
        private readonly CoreDbContext? _context;
        private readonly DbSet<UserModel> _dbSet;
        public UserService()
        {
            _context = new CoreDbContext();
            _dbSet = _context.Set<UserModel>();
        }
        //destructor
        ~UserService()
        {
            _context.SaveChanges();
        }

        public void add(UserModel user)
        {
            user.CreatedAt = DateTime.Now;
            _dbSet.Add(user);
        }

        public void delete(int id)
        {
            var user = _dbSet.Find(id);
            _dbSet.Remove(user);
        }

        public UserModel getById(int id)
        {
            // UserModel user = _dbSet.Include(p => p.Posts).FirstOrDefault(p => p.Id == id);
            UserModel user = _dbSet.Find(id);
            return user;
        }

        public UserModel[] getUsersByEmail(string? email)
        {
            IQueryable<UserModel> query = _dbSet;
            if (email != null)
            {
                query = query.Where(p => p.Email == email);
            }
            UserModel[] users = query.ToArray();
            return users;
        }

    }
}
