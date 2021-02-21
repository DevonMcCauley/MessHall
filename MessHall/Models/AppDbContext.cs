using Microsoft.EntityFrameworkCore;

namespace MessHall.Models
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Recipe> Recipes { get; set; }



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

            });

            modelBuilder.Entity<Recipe>().HasData(new Recipe
            {
                RecipeId = 2,
                Name = "Lasagna",
                Description = "A hearty lasagna",

            });

            modelBuilder.Entity<Recipe>().HasData(new Recipe
            {
                RecipeId = 3,
                Name = "Pizza",
                Description = "A classic American pizza",

            });


        }
    }
}
