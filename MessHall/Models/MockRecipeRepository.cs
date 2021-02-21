using System.Collections.Generic;
using System.Linq;

namespace MessHall.Models
{
    public class MockRecipeRepository : IRecipeRepository
    {
        public IEnumerable<Recipe> AllRecipes =>
            new List<Recipe>
            {
                new Recipe{RecipeId = 1, Name = "Apple Pie", Description = "A delicious apple pie."},
                new Recipe{RecipeId = 2, Name = "Lasagna", Description = "A hearty lasagna"},
                new Recipe{RecipeId = 3, Name = "Pizza", Description = "A classic American pizza"}
            };

        public Recipe GetRecipeById(int recipeId)
        {
            return AllRecipes.FirstOrDefault(r => r.RecipeId == recipeId);
        }
    }
}
