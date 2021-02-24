using MessHall.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace MessHall.Pages.Recipes
{
    public class DetailModel : PageModel
    {
        // Recipe repository
        private readonly IRecipeRepository recipeRepository;

        // Ingredient Repository
        private readonly IIngredientRepository ingredientRepository;

        // Recipe
        public Recipe Recipe { get; set; }

        public IEnumerable<Ingredient> Ingredients { get; set; }

        // Constructor
        public DetailModel(IRecipeRepository recipeRepository, IIngredientRepository ingredientRepository)
        {
            this.recipeRepository = recipeRepository;
            this.ingredientRepository = ingredientRepository;
        }

        // OnGet method to dispaly recipe details
        // Will redirect to NotFound if a valid RecipeId was not passed (typically by user adding a typo to the URL)
        public IActionResult OnGet(int recipeId)
        {
            Recipe = recipeRepository.GetRecipeById(recipeId);

            Ingredients = ingredientRepository.RelatedIngredients(recipeId);

            if (Recipe == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}