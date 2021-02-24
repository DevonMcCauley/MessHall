using System.Collections.Generic;

namespace MessHall.Models
{
    public interface IIngredientRepository
    {

        // Interface for the Ingredient Repository for CRUD operations

        IEnumerable<Ingredient> GetIngredientsByName(string name);

        IEnumerable<Ingredient> AllIngredients { get; }

        Ingredient GetIngredientById(int ingredientId);

        Ingredient Add(Ingredient newIngredient);

        Ingredient Update(Ingredient updatedIngredient);

        Ingredient Delete(int ingredientId);

        int Commit();

    }

}









