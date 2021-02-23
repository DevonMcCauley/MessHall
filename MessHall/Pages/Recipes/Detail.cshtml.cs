using MessHall.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MessHall.Pages.Recipes
{
    public class DetailModel : PageModel
    {

        // Recipe repository property
        private readonly IRecipeRepository recipeRepository;

        // Recipe property
        public Recipe Recipe { get; set; }

        // Constructor
        public DetailModel(IRecipeRepository recipeRepository)
        {
            this.recipeRepository = recipeRepository;
        }


        // OnGet method to dispaly recipe details
        // Will redirect to NotFound if a valid RecipeId was not passed (typically by user adding a typo to the URL)
        public IActionResult OnGet(int recipeId)
        {
            Recipe = recipeRepository.GetRecipeById(recipeId);
            if (Recipe == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();

        }
    }
}
