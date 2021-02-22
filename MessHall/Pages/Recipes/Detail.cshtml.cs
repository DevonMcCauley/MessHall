using MessHall.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MessHall.Pages.Recipes
{
    public class DetailModel : PageModel
    {
        private readonly IRecipeRepository recipeRepository;

        public Recipe Recipe { get; set; }

        public DetailModel(IRecipeRepository recipeRepository)
        {
            this.recipeRepository = recipeRepository;
        }

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
