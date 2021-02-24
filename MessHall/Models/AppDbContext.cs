using Microsoft.EntityFrameworkCore;

namespace MessHall.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        // Creates DBSets for the database to work with Ingredients and Recipes
        public DbSet<Recipe> Recipes { get; set; }

        public DbSet<Ingredient> Ingredients { get; set; }

        // Generates data for the database (useful after migration)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Recipe

            modelBuilder.Entity<Recipe>().HasData(new
            {
                RecipeId = 1,
                Name = "Apple Pie",
                Description = "A description of a pie",
                Notes = "Sample notes"
            }
            );

            modelBuilder.Entity<Recipe>().HasData(new
            {
                RecipeId = 2,
                Name = "Lasagna",
                Description = "A description of a lasagna",
                Notes = "Sample notes"
            }
            );

            modelBuilder.Entity<Recipe>().HasData(new
            {
                RecipeId = 3,
                Name = "Spaghetti",
                Description = "A description of spaghetti",
                Notes = "Sample notes"
            }
            );

            // Seed Ingredients

            modelBuilder.Entity<Ingredient>()
              .HasData(new
              {
                  IngredientId = 1,
                  Name = "Apple",
                  Description = "An apple",
                  CaloriesPerUnit = 50.0,
                  RecipeId = 1
              }
              );

            modelBuilder.Entity<Ingredient>()
              .HasData(new
              {
                  IngredientId = 2,
                  Name = "Sugar",
                  Description = "Some sugar",
                  CaloriesPerUnit = 150.0,
                  RecipeId = 1
              }
              );

            modelBuilder.Entity<Ingredient>()
             .HasData(new
             {
                 IngredientId = 3,
                 Name = "Meat",
                 Description = "Some meat",
                 CaloriesPerUnit = 350.0,
                 RecipeId = 2
             }
             );

            modelBuilder.Entity<Ingredient>()
             .HasData(new
             {
                 IngredientId = 4,
                 Name = "Garlic",
                 Description = "Some garlic",
                 CaloriesPerUnit = 10.0,
                 RecipeId = 2
             }
             );

            modelBuilder.Entity<Ingredient>()
             .HasData(new
             {
                 IngredientId = 5,
                 Name = "Sauce",
                 Description = "Some sauce",
                 CaloriesPerUnit = 200.0,
                 RecipeId = 3
             }
             );

            modelBuilder.Entity<Ingredient>()
              .HasData(new
              {
                  IngredientId = 6,
                  Name = "Pasta",
                  Description = "Some pasta",
                  CaloriesPerUnit = 100.0,
                  RecipeId = 3
              }
              );
        }
    }
}