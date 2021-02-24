using MessHall.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MessHall.Pages.Ingredients
{
    public class DetailModel : PageModel
    {
        // Ingredient repository
        private readonly IIngredientRepository ingredientRepository;

        // Ingredient property
        public Ingredient Ingredient { get; set; }

        // Constructor
        public DetailModel(IIngredientRepository ingredientRepository)
        {
            this.ingredientRepository = ingredientRepository;
        }


        // OnGet method to dispaly ingredient details
        // Will redirect to NotFound if a valid IngredientId was not passed (typically by user adding a typo to the URL)
        public IActionResult OnGet(int ingredientId)
        {
            Ingredient = ingredientRepository.GetIngredientById(ingredientId);
            if (Ingredient == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();

        }
    }
}
