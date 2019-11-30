using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERcipePresentation.Repositories;
using ERecipePresentation.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ERcipePresentation.Controllers
{
    public class IngredientsController : Controller
    {
        IIngredientRepository _ingredientRepository;

        public IngredientsController(IIngredientRepository ingredientRepository)
        {
            _ingredientRepository = ingredientRepository;
        }

        public IActionResult Index()
        {
            var ingredients = _ingredientRepository.GetIngredients();

            if (ingredients.Count() <= 0)
            {
                ViewBag.Message = "There was a problem retrieving ingredients from database or no ingredient exists";
            }
            return View(ingredients);
        }

        public IActionResult GetIngredientById(int ingredientId)
        {
            var ingredient = _ingredientRepository.GetIngredient(ingredientId);
            if (ingredient == null)
            {
                ModelState.AddModelError("", "Error getting a category");
                ViewBag.Message = $"There was a problem retrieving ingredient with id {ingredientId} " +
                    $"from the database or no ingredient with that id exists";
                ingredient = new IngredientDto();
            }
            return View(ingredient);
        }
    }
}