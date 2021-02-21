using MessHall.Models;
using MessHall.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MessHall.Controllers
{
    public class RecipeController : Controller
    {


        // Creates Recipe repository object 
        private readonly IRecipeRepository _recipeRepository;


        // Constructor for Controller
        public RecipeController(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        // Action method returns a ViewResult to show all recipes to the user
        // Calls the List.cshtml view
        public ViewResult List()
        {

            RecipesListViewModel recipesListViewModel = new RecipesListViewModel();
            recipesListViewModel.Recipes = _recipeRepository.AllRecipes;

            return View(recipesListViewModel);
        }


        // Routes a given recipe to the details page
        public IActionResult Details(int id)
        {
            var recipe = _recipeRepository.GetRecipeById(id);
            if (recipe == null)
            {
                return NotFound();
            }
            else
            {
                return View(recipe);
            }
        }
    }
}
