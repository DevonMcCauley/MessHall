using MessHall.Models;
using MessHall.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MessHall.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRecipeRepository _recipeRepository;

        public HomeController(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                AllRecipes = _recipeRepository.AllRecipes
            };

            return View(homeViewModel);
        }


    }
}

