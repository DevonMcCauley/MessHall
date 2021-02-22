using MessHall.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace MessHall.Pages.Recipes
{
    public class ListModel : PageModel
    {
        private readonly IRecipeRepository recipeRepository;

        public IEnumerable<Recipe> Recipes { get; set; }

        public ListModel(IRecipeRepository recipeRepository)
        {
            this.recipeRepository = recipeRepository;
        }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public void OnGet()
        {
            Recipes = recipeRepository.GetRecipesByName(SearchTerm);
        }
    }
}
