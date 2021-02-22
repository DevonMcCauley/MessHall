using MessHall.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace MessHall.Pages.Ingredients
{
    public class ListModel : PageModel
    {
        private readonly IIngredientRepository ingredientRepository;

        public IEnumerable<Ingredient> Ingredients { get; set; }

        public ListModel(IIngredientRepository ingredientRepository)
        {
            this.ingredientRepository = ingredientRepository;
        }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public void OnGet()
        {

            Ingredients = ingredientRepository.GetIngredientsByName(SearchTerm);
        }
    }
}
