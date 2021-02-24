using MessHall.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MessHall.Pages.Ingredients
{
    public class EditModel : PageModel
    {   // Ingredient Repository
        private readonly IIngredientRepository ingredientRepository;

        // Ingredient Repository
        [BindProperty]
        public Ingredient Ingredient { get; set; }

        // Constructor
        public EditModel(IIngredientRepository ingredientRepository)
        {
            this.ingredientRepository = ingredientRepository;
        }




        // OnGet method to bring in ingredient data passed from the List page. 
        // If the IngredientId is null, user will be redirected to the NotFound page
        // Will create a new Ingredient if not updating an existing Recipe
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


        // OnPost method that allows user to save the ingredient changes
        // If there is no IngredientId, assumes it is a new Ingredient and will add a new Ingredient to the database

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