using MessHall.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace MessHall.Pages.Recipes
{
    public class ListModel : PageModel
    {
        // Recipe Repository
        private readonly IRecipeRepository recipeRepository;

        // Recipe
        public IEnumerable<Recipe> Recipes { get; set; }

        // Constructor
        public ListModel(IRecipeRepository recipeRepository)
        {
            this.recipeRepository = recipeRepository;
        }

        // Creates the SearchTerm to allow user to search for a recipe
        // SearchTerm is bound with SupportsGet to permit it be used in a Get operation (this will display all recipes to the list if null)
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }


        // OnGet method
        public void OnGet()
        {
            // If null, all recipes will be shown, otherwise allows for searching for a specic recipe
            Recipes = recipeRepository.GetRecipesByName(SearchTerm);
        }
    }
}
