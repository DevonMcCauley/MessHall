using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MessHall.Models
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly AppDbContext appDbContext;


        public RecipeRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }



        public Recipe Add(Recipe newRecipe)
        {
            appDbContext.Add(newRecipe);
            return newRecipe;
        }

        public IEnumerable<Recipe> AllRecipes
        {
            get
            {
                return appDbContext.Recipes;
            }
        }

        public int Commit()
        {
            return appDbContext.SaveChanges();

        }

        public Recipe Delete(int recipeId)
        {
            var recipe = GetRecipeById(recipeId);
            if (recipe != null)
            {
                appDbContext.Recipes.Remove(recipe);
            }

            return recipe;
        }

        public Recipe GetRecipeById(int recipeId)
        {
            return appDbContext.Recipes.Find(recipeId);
        }

        public Recipe Update(Recipe updatedRecipe)
        {
            var rec = appDbContext.Recipes.Attach(updatedRecipe);
            rec.State = EntityState.Modified;
            return updatedRecipe;
        }

        public IEnumerable<Recipe> GetRecipesByName(string name)
        {
            var query = from r in appDbContext.Recipes
                        where r.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby r.Name
                        select r;
            return query;

        }
    }
}
