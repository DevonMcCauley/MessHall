using MessHall.Models;
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

        public void OnGet()
        {
            Recipes = recipeRepository.AllRecipes;
        }
    }
}
