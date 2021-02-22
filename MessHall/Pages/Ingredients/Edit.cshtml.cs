using MessHall.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MessHall.Pages.Ingredients
{
    public class EditModel : PageModel
    {
        private readonly IIngredientRepository ingredientRepository;

        [BindProperty]
        public Ingredient Ingredient { get; set; }


        public EditModel(IIngredientRepository ingredientRepository)
        {
            this.ingredientRepository = ingredientRepository;
        }

        public IActionResult OnGet(int? ingredientId)
        {
            if (ingredientId.HasValue)
            {
                Ingredient = ingredientRepository.GetIngredientById(ingredientId.Value);
            }
            else
            {
                Ingredient = new Ingredient();
            }
            if (Ingredient == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (Ingredient.IngredientId > 0)
            {
                ingredientRepository.Update(Ingredient);
            }
            else
            {
                ingredientRepository.Add(Ingredient);
            }
            ingredientRepository.Commit();
            TempData["Message"] = "Ingredient Saved!";
            return RedirectToPage("./List");
        }
    }
}