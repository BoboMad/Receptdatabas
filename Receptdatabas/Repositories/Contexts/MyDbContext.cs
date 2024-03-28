using Microsoft.EntityFrameworkCore;
using Receptdatabas.Repositories.Models.Entities;

namespace Receptdatabas.Repositories.Contexts
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Recipe> Recipes { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }
        public virtual DbSet<Category> Categories { get; set; }

        //Sätter upp delete behavior
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Recipe>()
            .HasOne(r => r.Category)
            .WithMany(c => c.Recipes)
            .HasForeignKey(r => r.CategoryId)
            .OnDelete(DeleteBehavior.Restrict); 

            // Rating - Recipe relationship
            modelBuilder.Entity<Rating>()
            .HasOne(r => r.Recipe)
            .WithMany(rec => rec.Ratings)
            .HasForeignKey(r => r.RecipeId)
            .OnDelete(DeleteBehavior.Cascade); 

            // Recipe - User relationship
            modelBuilder.Entity<Recipe>()
            .HasOne(r => r.User)
            .WithMany(u => u.Recipes)
            .HasForeignKey(r => r.UserId)
            .OnDelete(DeleteBehavior.Cascade); 

            modelBuilder.Entity<Rating>()
            .HasOne(r => r.User)
            .WithMany() 
            .HasForeignKey(r => r.UserID)
            .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Category>()
            .HasMany(c => c.Recipes)
            .WithOne(r => r.Category)
            .HasForeignKey(r => r.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
