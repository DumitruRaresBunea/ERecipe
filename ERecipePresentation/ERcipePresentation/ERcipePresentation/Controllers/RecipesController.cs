using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERcipePresentation.Repositories;
using ERecipePresentation.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ERcipePresentation.Controllers
{
    public class RecipesController : Controller
    {
        IRecipeRepository _recipeRepository;

        public RecipesController(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        public IActionResult Index()
        {
            var recipes = _recipeRepository.GetRecipes();

            if (recipes.Count() <= 0)
            {
                ViewBag.Message = "There was a problem retrieving recipes from database or no recipe exists";
            }
            return View(recipes);
        }

        public IActionResult GetRecipeById(int recipeId)
        {
            var recipe = _recipeRepository.GetRecipe(recipeId);
            if (recipe == null)
            {
                ModelState.AddModelError("", "Error getting a category");
                ViewBag.Message = $"There was a problem retrieving recipe with id {recipeId} " +
                    $"from the database or no recipe with that id exists";
                recipe = new RecipeDto();
            }
            return View(recipe);
        }
    }
}