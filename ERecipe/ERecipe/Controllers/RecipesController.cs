using ERecipe.DTO;
using ERecipe.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ERecipe.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : Controller
    {
        private IRecipeRepository _recipeRepository;

        public RecipesController(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        //api/recipes
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<RecipeDto>))]
        [ProducesResponseType(400)]
        public IActionResult GetRecipes()
        {
            var recipes = _recipeRepository.GetRecipes();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var recipesDto = new List<RecipeDto>();

            foreach (var recipe in recipes)
            {
                recipesDto.Add(new RecipeDto
                {
                    Id = recipe.Id,
                    Name = recipe.Name,
                    Description = recipe.Description,
                    PublishDate = recipe.PublishDate
                });
            }
            return Ok(recipesDto);
        }

        //api/recipes/recipeId
        [HttpGet("{recipeId}")]
        [ProducesResponseType(200, Type = typeof(RecipeDto))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetBook(int recipeId)
        {
            if (!_recipeRepository.RecipeExists(recipeId))
                return NotFound();

            var recipe = _recipeRepository.GetRecipe(recipeId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var recipeDto = new RecipeDto()
            {
                Id = recipe.Id,
                Name = recipe.Name,
                Description = recipe.Description,
                PublishDate = recipe.PublishDate
            };

            return Ok(recipeDto);
        }

        //api/recipes/recipeId/rating
        [HttpGet("{recipeId}/rating")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetRecipeId(int recipeId)
        {
            if (!_recipeRepository.RecipeExists(recipeId))
                return NotFound();

            var rating = _recipeRepository.GetRecipeRatingAverage(recipeId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(rating);
        }
    }
}