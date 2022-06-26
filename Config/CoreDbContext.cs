using Microsoft.EntityFrameworkCore;
using daily_blog.Models;

public class CoreDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySQL("server=byandv3pojguajzqkjji-mysql.services.clever-cloud.com;database=byandv3pojguajzqkjji;user=upmki84bdpxxs90h;password=Csnu07rg9MwXQ0tc3t6h");
    }


    public DbSet<UserModel>? UserModel { get; set; }
    public DbSet<PostModel>? PostModel { get; set; }
    public DbSet<BookmarkModel>? BookmarkModels { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<UserModel>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Username).IsRequired();
            entity.Property(e => e.Password).IsRequired();
            entity.Property(e => e.Email).IsRequired();
            entity.Property(e => e.Role).IsRequired();
            entity.Property(e => e.CreatedAt).IsRequired();
            entity.HasMany(e => e.Posts).WithOne(e => e.Author).HasForeignKey(e => e.AuthorId);
            entity.HasMany(e => e.Bookmarks).WithOne(e => e.User).HasForeignKey(e => e.UserId);
        });

        modelBuilder.Entity<PostModel>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Title);
            entity.Property(e => e.Image);
            entity.Property(e => e.Url);
            entity.Property(e => e.AuthorId).IsRequired();
            entity.Property(e => e.CreatedAt);
            entity.Property(e => e.Upvote);
            entity.HasOne(e => e.Author).WithMany(e => e.Posts).HasForeignKey(e => e.AuthorId);
            entity.HasMany(e => e.Bookmarks).WithOne(e => e.Post).HasForeignKey(e => e.PostId);
        });

        modelBuilder.Entity<BookmarkModel>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.UserId).IsRequired();
            entity.Property(e => e.PostId).IsRequired();
            entity.Property(e => e.CreatedAt);
            entity.HasOne(e => e.User).WithMany(e => e.Bookmarks).HasForeignKey(e => e.UserId);
            entity.HasOne(e => e.Post).WithMany(e => e.Bookmarks).HasForeignKey(e => e.PostId);
        });
    }
}