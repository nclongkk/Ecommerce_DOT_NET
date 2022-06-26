using Microsoft.EntityFrameworkCore;
using Ecommerce_DOT_NET.Models;

public class CoreDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySQL("server=bantapwwqez1nxepcw7c-mysql.services.clever-cloud.com;database=bantapwwqez1nxepcw7c;user=unxxepntdepdwybc;password=QPAVx3sUEP8VFAqsnpCo");
    }

    // create generic DbSet for each model

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