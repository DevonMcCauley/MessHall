using System.Collections.Generic;

namespace MessHall.Models
{
    public interface IRecipeRepository
    {

        IEnumerable<Recipe> AllRecipes { get; }

        Recipe GetRecipeById(int recipeId);

        Recipe Add(Recipe newRecipe);

        Recipe Update(Recipe updatedRecipe);

        Recipe Delete(int recipeId);

        int Commit();


    }
}
