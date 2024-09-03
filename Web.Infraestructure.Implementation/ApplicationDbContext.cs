using Microsoft.EntityFrameworkCore;
using System;
using Web.Domain.Entities;

namespace Web.Infraestructure.Implementation
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Questions> Questions { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>()
                .HasMany(a => a.Questions)
                .WithOne(b => b.Categories)
                .HasForeignKey(b => b.CategoryId);
        }

    }
}
