using MessHall.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MessHall.Pages.Recipes
{
    public class EditModel : PageModel
    {
        private readonly IRecipeRepository recipeRepository;

        [BindProperty]
        public Recipe Recipe { get; set; }

        public EditModel(IRecipeRepository recipeRepository)
        {
            this.recipeRepository = recipeRepository;
        }


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
