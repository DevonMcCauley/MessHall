using MessHall.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace MessHall.Pages.Ingredients
{
    public class ListModel : PageModel
    {
        // Ingredient Repository
        private readonly IIngredientRepository ingredientRepository;

        // Ingredient
        public IEnumerable<Ingredient> Ingredients { get; set; }

        // Constructor
        public ListModel(IIngredientRepository ingredientRepository)
        {
            this.ingredientRepository = ingredientRepository;
        }

        // Creates the SearchTerm to allow user to search for an ingredient
        // SearchTerm is bound with SupportsGet to permit it be used in a Get operation (this will display all ingredients to the list if null)
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }


        // OnGet method
        public void OnGet()
        {
            // If null, all recipes will be shown, otherwise allows for searching for a specific ingredient
            Ingredients = ingredientRepository.GetIngredientsByName(SearchTerm);
        }
    }
}
