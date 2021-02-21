using System.Collections.Generic;

namespace MessHall.Models
{
    public interface IRecipeRepository
    {

        IEnumerable<Recipe> AllRecipes { get; }

        Recipe GetRecipeById(int recipeId);

    }
}
