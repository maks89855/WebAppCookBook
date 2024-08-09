using Microsoft.EntityFrameworkCore;
using WebAppCookBook.Models;

namespace WebAppCookBook.DbContexts
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Recipe> Recipes { get; set; } = null!;
        public DbSet<Ingredient> Ingredients { get; set; } = null!;
        public DbSet<StepCook> StepCooks { get; set; } = null!;
        public ApplicationContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(

                new Category 
                { 
                    Id = 1,
                    NameCategory = "first"
                },
                new Category
                {
                    Id = 2,
                    NameCategory = "second"
                },
                new Category
                {
                    Id = 3,
                    NameCategory = "third"
                },
                new Category
                {
                    Id = 4,
                    NameCategory = "fourth"
                }
            );
            modelBuilder.Entity<Recipe>().HasData(

                new Recipe
                {
                    Id = 1,
                    Name = "first",
                    CategoryId = 1,
                },
                new Recipe
                {
                    Id = 2,
                    Name = "second",
                    CategoryId = 2,
                },
                new Recipe
                {
                    Id = 3,
                    Name = "third",
                    CategoryId = 1,
                },
                new Recipe
                {
                    Id = 4,
                    Name = "fourth",
                    CategoryId = 3,
                }
            );
            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient
                {
                    Id = 1,
                    RecipeId = 1,
                    NameIngredient = "First",
                    Count = 1,
                    Units = API.Models.Unit.г
                }
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}
