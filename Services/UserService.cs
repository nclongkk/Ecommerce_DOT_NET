using Ecommerce_DOT_NET.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_DOT_NET.Services
{
    public class UserService
    {
        private CoreDbContext context;
        public UserService()
        {
            _context = context;
            _dbSet = _context.Set<UserModel>();
        }
        private readonly CoreDbContext? _context;
        private readonly DbSet<UserModel> _dbSet;

        public void add(UserModel user)
        {
            _dbSet.Add(user);
            _context.SaveChanges();
        }

        public void delete(int id)
        {
            var user = _dbSet.Find(id);
            _dbSet.Remove(user);
            _context.SaveChanges();
        }
    }
}
