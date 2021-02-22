using MessHall.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MessHall.Pages.Recipes
{
    public class DeleteModel : PageModel
    {
        private readonly IRecipeRepository recipeRepository;

        public Recipe Recipe { get; set; }

        public DeleteModel(IRecipeRepository recipeRepository)
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
