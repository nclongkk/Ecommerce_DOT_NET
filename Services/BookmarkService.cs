using daily_blog.Models;
using Microsoft.EntityFrameworkCore;

namespace daily_blog.Services
{
    public class BookmarkService
    {
        private CoreDbContext context;
        private readonly CoreDbContext? _context;
        private readonly DbSet<BookmarkModel> _dbSet;
        public BookmarkService()
        {
            _context = new CoreDbContext();
            _dbSet = _context.Set<BookmarkModel>();
        }
        //destructor
        // ~BookmarkService()
        // {
        //     _context.SaveChanges();
        // }

        public void add(BookmarkModel bookmark)
        {
            bookmark.CreatedAt = DateTime.Now;
            _dbSet.Add(bookmark);
            _context.SaveChanges();
        }

        public void delete(int id)
        {
            var bookmark = _dbSet.Find(id);
            _dbSet.Remove(bookmark);
        }


        public BookmarkModel[] getAllBookmarkOfUser(int id)
        {
            BookmarkModel[] bookmarks = _dbSet.Include(p => p.Post).Where(p => p.UserId == id).ToArray();
            return bookmarks;
        }

    }
}
