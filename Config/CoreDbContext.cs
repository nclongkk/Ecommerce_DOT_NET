using Microsoft.EntityFrameworkCore;
using Ecommerce_DOT_NET.Models;

public class CoreDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySQL("server=byandv3pojguajzqkjji-mysql.services.clever-cloud.com;database=byandv3pojguajzqkjji;user=upmki84bdpxxs90h;password=Csnu07rg9MwXQ0tc3t6h");
    }


    public DbSet<UserModel>? UserModel { get; set; }
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
        });

    }


}