using ERecipe.Models;
using Microsoft.EntityFrameworkCore;

namespace ERecipe.Services
{
    public class RecipeDbContext : DbContext
    {
        public RecipeDbContext(DbContextOptions<RecipeDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Recipe> Recipes { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Ingredient> Ingredients { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Reviewer> Reviewers { get; set; }
        public virtual DbSet<RecipeAuthor> RecipeAuthors { get; set; }
        public virtual DbSet<RecipeCategory> RecipeCategories { get; set; }
        public virtual DbSet<RecipeIngredient> RecipeIngredients { get; set; }
        public virtual DbSet<Step> Steps { get; set; }
        public virtual DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RecipeCategory>()
                .HasKey(rc => new { rc.RecipeId, rc.CategoryId });
            modelBuilder.Entity<RecipeCategory>()
                .HasOne(r => r.Recipe)
                .WithMany(rc => rc.RecipeCategories)
                .HasForeignKey(r => r.RecipeId);
            modelBuilder.Entity<RecipeCategory>()
                .HasOne(c => c.Category)
                .WithMany(rc => rc.RecipeCategories)
                .HasForeignKey(c => c.CategoryId);

            modelBuilder.Entity<RecipeAuthor>()
               .HasKey(ra => new { ra.RecipeId, ra.AuthorID });
            modelBuilder.Entity<RecipeAuthor>()
                .HasOne(r => r.Recipe)
                .WithMany(ra => ra.RecipeAuthors)
                .HasForeignKey(r => r.RecipeId);
            modelBuilder.Entity<RecipeAuthor>()
                .HasOne(a => a.Author)
                .WithMany(ra => ra.RecipeAuthors)
                .HasForeignKey(a => a.AuthorID);

            modelBuilder.Entity<RecipeIngredient>()
               .HasKey(ri => new { ri.RecipeId, ri.IngredientId });
            modelBuilder.Entity<RecipeIngredient>()
                .HasOne(r => r.Recipe)
                .WithMany(ri => ri.RecipeIngredients)
                .HasForeignKey(r => r.RecipeId);
            modelBuilder.Entity<RecipeIngredient>()
                .HasOne(i => i.Ingredient)
                .WithMany(ri => ri.RecipeIngredients)
                .HasForeignKey(i => i.IngredientId);
        }
    }
}