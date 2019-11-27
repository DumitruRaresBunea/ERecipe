using ERecipe.DTO;
using ERecipe.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ERecipe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientsController : Controller
    {
        private IIngredientRepository _ingredientRepository;
        private IRecipeRepository _recipeRepository;

        public IngredientsController(IIngredientRepository ingredientRepository, IRecipeRepository recipeRepository)
        {
            _ingredientRepository = ingredientRepository;
            _recipeRepository = recipeRepository;
        }

        //api/ingredients
        [HttpGet]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<IngredientDto>))]
        public IActionResult GetCountries()
        {
            var ingredients = _ingredientRepository.GetIngredients().ToList();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var ingredientsDto = new List<IngredientDto>();
            foreach (var ingredient in ingredients)
            {
                ingredientsDto.Add(new IngredientDto
                {
                    Id = ingredient.Id,
                    Name = ingredient.Name,
                    Quantity = ingredient.Quantity
                });
            }
            return Ok(ingredientsDto);
        }

        //api/ingredients/ingredientId
        [HttpGet("{ingredientId}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(IngredientDto))]
        public IActionResult GetCountry(int ingredientId)
        {
            if (!_ingredientRepository.IngredientExists(ingredientId))
                return NotFound();

            var ingredient = _ingredientRepository.GetIngredient(ingredientId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var ingredientDto = new IngredientDto()
            {
                Id = ingredient.Id,
                Name = ingredient.Name,
                Quantity = ingredient.Quantity
            };

            return Ok(ingredientDto);
        }

        //api/ingredients/recipes/recipeId
        [HttpGet("recipes/{recipeId}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<IngredientDto>))]
        public IActionResult GetIngredientssOFRecipe(int recipeId)
        {
            if (!_recipeRepository.RecipeExists(recipeId))
                return NotFound();

            var ingredients = _ingredientRepository.GetIngredientsOfARecipe(recipeId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var ingredientsDto = new List<IngredientDto>();

            foreach (var ingredient in ingredients)
            {
                ingredientsDto.Add(new IngredientDto()
                {
                    Id = ingredient.Id,
                    Name = ingredient.Name,
                    Quantity = ingredient.Quantity
                });
            }

            return Ok(ingredientsDto);
        }

        //api/ingredients/ingredientId/recipes
        [HttpGet("{ingredientId}/recipes")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(RecipeDto))]
        public IActionResult GetRecipeFromIngredient(int ingredientId)
        {
            if (!_ingredientRepository.IngredientExists(ingredientId))
                return NotFound();

            var recipe = _ingredientRepository.GetRecipeOfAIngredient(ingredientId);

            if (!ModelState.IsValid)
                return BadRequest();

            var recipeDto = new RecipeDto()
            {
                Id = recipe.Id,
                Name = recipe.Name,
                Description = recipe.Description,
                PublishDate = recipe.PublishDate
            };

            return Ok(recipeDto);
        }
    }
}