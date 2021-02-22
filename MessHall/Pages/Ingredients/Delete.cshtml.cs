using MessHall.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MessHall.Pages.Ingredients
{
    public class DeleteModel : PageModel
    {

        private readonly IIngredientRepository ingredientRepository;

        public Ingredient Ingredient { get; set; }

        public DeleteModel(IIngredientRepository ingredientRepository)
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







