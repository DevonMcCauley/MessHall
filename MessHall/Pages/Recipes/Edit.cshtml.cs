using MessHall.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MessHall.Pages.Recipes
{
    public class EditModel : PageModel
    {

        // Recipe Repository
        private readonly IRecipeRepository recipeRepository;

        // Recipe
        [BindProperty]
        public Recipe Recipe { get; set; }


        // Constructor
        public EditModel(IRecipeRepository recipeRepository)
        {
            this.recipeRepository = recipeRepository;
        }


        // OnGet method to bring in recipe data passed from the List page. 
        // If the RecipeId is null, user will be redirected to the NotFound page
        // Will create a new Recipe if not updating an existing Recipe
        public IActionResult OnGet(int? recipeId)
        {

            if (recipeId.HasValue)
            {
                Recipe = recipeRepository.GetRecipeById(recipeId.Value);
            }
            else
            {
                Recipe = new Recipe();
            }
            if (Recipe == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }


        // OnPost method that allows user to save the recipe changes
        // If there is no RecipeId, assumes it is a new Recipe and will add a new Recipe to the database
        public IActionResult OnPost()
        {
            if (Recipe.RecipeId > 0)
            {
                recipeRepository.Update(Recipe);
            }
            else
            {
                recipeRepository.Add(Recipe);
            }
            recipeRepository.Commit();
            TempData["Message"] = "Recipe Saved!";
            return RedirectToPage("./List");
        }

    }
}
