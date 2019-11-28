using ERecipe.DTO;
using ERecipe.Models;
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
        public IActionResult GetIngredients()
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
        [HttpGet("{ingredientId}", Name = "GetIngredient")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(IngredientDto))]
        public IActionResult GetIngredient(int ingredientId)
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

        //api/ingredients
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Ingredient))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult CreateIngredient([FromBody]Ingredient ingredientToCreate)
        {
            if (ingredientToCreate == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_ingredientRepository.CreateIngredient(ingredientToCreate))
            {
                ModelState.AddModelError("", $"Something went wrong saving the ingredient " +
                                            $"{ingredientToCreate.Name}");
                return StatusCode(500, ModelState);
            }

            return CreatedAtRoute("GetIngredient", new { ingredientId = ingredientToCreate.Id }, ingredientToCreate);
        }

        //api/ingredients/ingredientId
        [HttpPut("{ingredientId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult UpdateIngredient(int ingredientId, [FromBody]Ingredient ingredientToUpdate)
        {
            if (ingredientToUpdate == null)
                return BadRequest(ModelState);

            if (ingredientId != ingredientToUpdate.Id)
                return BadRequest(ModelState);

            if (!_ingredientRepository.IngredientExists(ingredientId))
                ModelState.AddModelError("", "Ingredient doesn't exist!");

            if (!ModelState.IsValid)
                return StatusCode(404, ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_ingredientRepository.UpdateIngredient(ingredientToUpdate))
            {
                ModelState.AddModelError("", $"Something went wrong updating the author " +
                                            $"{ingredientToUpdate.Name}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        //api/ingredients/ingredientId
        [HttpDelete("{ingredientId}")]
        [ProducesResponseType(204)] //no content
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(409)]
        [ProducesResponseType(500)]
        public IActionResult DeleteIngredient(int ingredientId)
        {
            if (!_ingredientRepository.IngredientExists(ingredientId))
                return NotFound();

            var ingredientToDelete = _ingredientRepository.GetIngredient(ingredientId);

            if (_ingredientRepository.GetIngredientsOfARecipe(ingredientId).Count > 0)
            {
                ModelState.AddModelError("", $"Ingredient {ingredientToDelete.Name}  " +
                                              "cannot be deleted because it is associated with at least one recipe");
                return StatusCode(409, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_ingredientRepository.DeleteIngredient(ingredientToDelete))
            {
                ModelState.AddModelError("", $"Something went wrong deleting " +
                                            $"{ingredientToDelete.Name}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}