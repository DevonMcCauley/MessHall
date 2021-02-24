using MessHall.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MessHall.Pages.Ingredients
{
    public class DeleteModel : PageModel
    {


        // Ingredient repository
        private readonly IIngredientRepository ingredientRepository;

        // Ingredient
        public Ingredient Ingredient { get; set; }

        // Constructor
        public DeleteModel(IIngredientRepository ingredientRepository)
        {
            this.ingredientRepository = ingredientRepository;
        }

        // OnGet method to bring in correct ingredient
        // Redirects to NotFound if passed invalid IngredientId (bad URL)
        public IActionResult OnGet(int ingredientId)
        {

            Ingredient = ingredientRepository.GetIngredientById(ingredientId);
            if (Ingredient == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        // OnPost processes deletion
        public IActionResult OnPost(int ingredientId)
        {
            var ingredient = ingredientRepository.Delete(ingredientId);
            ingredientRepository.Commit();
            if (ingredient == null)
            {
                return RedirectToPage("./NotFound");
            }

            TempData["Message"] = $"{ingredient.Name} deleted";
            return RedirectToPage("./List");
        }

    }
}







