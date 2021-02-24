using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MessHall.Models
{
    public class IngredientRepository : IIngredientRepository
    {
        // Ingredient Repository to support CRUD operations with the Recipe class

        private readonly AppDbContext appDbContext;

        public IngredientRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public IEnumerable<Ingredient> AllIngredients
        {
            get
            {
                return appDbContext.Ingredients;
            }
        }

        public Ingredient Add(Ingredient newIngredient)
        {
            appDbContext.Add(newIngredient);
            return newIngredient;
        }

        public int Commit()
        {
            return appDbContext.SaveChanges();
        }

        public Ingredient Delete(int ingredientId)
        {
            var ingredient = GetIngredientById(ingredientId);
            if (ingredient != null)
            {
                appDbContext.Ingredients.Remove(ingredient);
            }

            return ingredient;
        }

        public Ingredient GetIngredientById(int ingredientId)
        {
            return appDbContext.Ingredients.Find(ingredientId);
        }

        public IEnumerable<Ingredient> GetIngredientsByName(string name)
        {
            var query = from r in appDbContext.Ingredients
                        where r.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby r.Name
                        select r;
            return query;
        }

        public Ingredient Update(Ingredient updatedIngredient)
        {
            var rec = appDbContext.Ingredients.Attach(updatedIngredient);
            rec.State = EntityState.Modified;
            return updatedIngredient;
        }

        public IEnumerable<Ingredient> RelatedIngredients(int recipeId)
        {
            var query = from i in appDbContext.Ingredients
                        where i.RecipeId == recipeId
                        orderby i.Name
                        select i;
            return query;
        }
    }
}