using DogusTeknoloji.SibelCaliskan.Models.Repositories.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DogusTeknoloji.SibelCaliskan.Models.Repositories;

public class AppDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

    
    public DbSet<Blog> Blogs { get; set; } = null!;
     public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Comment> Comments { get; set; } = null!;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

}

