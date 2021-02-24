using System.Collections.Generic;

namespace MessHall.Models
{
    public interface IRecipeRepository
    {
        // Interface for the Recipe Repository for CRUD operations


        IEnumerable<Recipe> GetRecipesByName(string name);

        IEnumerable<Recipe> AllRecipes { get; }

        Recipe GetRecipeById(int recipeId);

        Recipe Add(Recipe newRecipe);

        Recipe Update(Recipe updatedRecipe);

        Recipe Delete(int recipeId);

        int Commit();


    }
}
