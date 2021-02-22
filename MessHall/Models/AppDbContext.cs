using Microsoft.EntityFrameworkCore;

namespace MessHall.Models
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }



        // Generates data for the database (useful after migration)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            // Seed recipes

            modelBuilder.Entity<Recipe>().HasData(new Recipe
            {
                RecipeId = 1,
                Name = "Apple Pie",
                Description = "A delicious apple pie.",
                Notes = "This apple pie contains 2 ingredients: apple and pie",

            });

            modelBuilder.Entity<Recipe>().HasData(new Recipe
            {
                RecipeId = 2,
                Name = "Lasagna",
                Description = "A hearty lasagna",
                Notes = "This this is a good lasagna",

            });

            modelBuilder.Entity<Recipe>().HasData(new Recipe
            {
                RecipeId = 3,
                Name = "Pizza",
                Description = "A classic American pizza",
                Notes = "This pizza is also good",
            });

            // Seed ingredients
            modelBuilder.Entity<Ingredient>().HasData(new Ingredient
            {
                IngredientId = 1,
                Name = "Apple",
                Description = "An apple",
                CaloriesPerUnit = 50.0,
            });

            modelBuilder.Entity<Ingredient>().HasData(new Ingredient
            {
                IngredientId = 2,
                Name = "Flour",
                Description = "Some flour",
                CaloriesPerUnit = 10.0,
            });

            modelBuilder.Entity<Ingredient>().HasData(new Ingredient
            {
                IngredientId = 3,
                Name = "Sauce",
                Description = "Some sauce",
                CaloriesPerUnit = 100.0,
            });

            modelBuilder.Entity<Ingredient>().HasData(new Ingredient
            {
                IngredientId = 4,
                Name = "Pepperoni",
                Description = "Turkey pepperoni",
                CaloriesPerUnit = 150.0,
            });


        }
    }
}
