using System.Collections.Generic;
using System.Linq;

namespace MessHall.Models
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly AppDbContext _appDbContext;


        public RecipeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Recipe> AllRecipes
        {
            get
            {
                return _appDbContext.Recipes;
            }
        }

        public Recipe GetRecipeById(int recipeId)
        {
            return _appDbContext.Recipes.FirstOrDefault(r => r.RecipeId == recipeId);
        }
    }
}
