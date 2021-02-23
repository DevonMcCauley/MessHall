using MessHall.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MessHall.Pages.Recipes
{
    public class DeleteModel : PageModel
    {
        // Recipe repository
        private readonly IRecipeRepository recipeRepository;


        // Recipe
        public Recipe Recipe { get; set; }

        // Constructor
        public DeleteModel(IRecipeRepository recipeRepository)
        {
            this.recipeRepository = recipeRepository;
        }



        // OnGet method to bring in correct recipe
        // Redirects to NotFound if passed invalid RecipeId (bad URL)
        public IActionResult OnGet(int recipeId)
        {

            Recipe = recipeRepository.GetRecipeById(recipeId);
            if (Recipe == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }


        // OnPost processes deletion
        public IActionResult OnPost(int recipeId)
        {
            var recipe = recipeRepository.Delete(recipeId);
            recipeRepository.Commit();
            if (recipe == null)
            {
                return RedirectToPage("./NotFound");
            }

            TempData["Message"] = $"{recipe.Name} deleted";
            return RedirectToPage("./List");
        }
    }
}
