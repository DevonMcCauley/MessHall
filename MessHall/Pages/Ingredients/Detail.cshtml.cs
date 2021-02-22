using MessHall.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MessHall.Pages.Ingredients
{
    public class DetailModel : PageModel
    {
        private readonly IIngredientRepository ingredientRepository;

        public Ingredient Ingredient { get; set; }

        public DetailModel(IIngredientRepository ingredientRepository)
        {
            this.ingredientRepository = ingredientRepository;
        }

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
