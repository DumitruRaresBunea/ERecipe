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
    public class RecipesController : Controller
    {
        private IRecipeRepository _recipeRepository;
        private IAuthorRepository _authorRepository;
        private ICategoryRepository _categoryRepository;
        private IReviewRepository _reviewRepository;
        private IStepRepository _stepRepository;
        private IIngredientRepository _ingredientRepository;
        private ICountryRepository _countryRepository;

        public RecipesController(IRecipeRepository recipeRepository, IAuthorRepository authorRepository, ICategoryRepository categoryRepository
            , IReviewRepository reviewRepository, IStepRepository stepRepository, IIngredientRepository ingredientRepository, ICountryRepository countryRepository)
        {
            _recipeRepository = recipeRepository;
            _authorRepository = authorRepository;
            _categoryRepository = categoryRepository;
            _reviewRepository = reviewRepository;
            _stepRepository = stepRepository;
            _ingredientRepository = ingredientRepository;
            _countryRepository = countryRepository;
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
        [HttpGet("{recipeId}", Name = "GetRecipe")]
        [ProducesResponseType(200, Type = typeof(RecipeDto))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetRecipe(int recipeId)
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

        private StatusCodeResult ValidateRecipe(List<int> authorsId, List<int> categoriesId, List<int> stepsId, List<int> ingredientsId, Recipe recipe)
        {
            recipe.Country = _countryRepository.GetCountry(recipe.Country.Id);

            if (recipe == null || authorsId.Count() <= 0 || categoriesId.Count() <= 0 || stepsId.Count() <= 0 || ingredientsId.Count() <= 0)
            {
                ModelState.AddModelError("", "Missing recipe, author, category, step, ingredient or country");
                return BadRequest();
            }

            foreach (var id in authorsId)
            {
                if (!_authorRepository.AuthorExists(id))
                {
                    ModelState.AddModelError("", "Author Not Found");
                    return StatusCode(404);
                }
            }

            foreach (var id in categoriesId)
            {
                if (!_categoryRepository.CategoryExists(id))
                {
                    ModelState.AddModelError("", "Category Not Found");
                    return StatusCode(404);
                }
            }

            foreach (var id in stepsId)
            {
                if (!_stepRepository.StepExists(id))
                {
                    ModelState.AddModelError("", "Step Not Found");
                    return StatusCode(404);
                }
            }

            foreach (var id in ingredientsId)
            {
                if (!_ingredientRepository.IngredientExists(id))
                {
                    ModelState.AddModelError("", "Ingredient Not Found");
                    return StatusCode(404);
                }
            }

            if (!_countryRepository.CountryExists(recipe.Country.Id))
            {
                ModelState.AddModelError("", "Country does not exist");
                return StatusCode(404);
            }

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Critical Error");
                return BadRequest();
            }

            return NoContent();
        }

        //api/recipes?authorsId=1&authorsId=2&categoriesId=1&categoriesId=2&stepsId=1&stepsId=2&ingredientsId=1&ingredientsId=2
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Recipe))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(422)]
        [ProducesResponseType(500)]
        public IActionResult CreteRecipe([FromQuery]List<int> authorsId, [FromQuery] List<int> categoriesId, [FromQuery] List<int> stepsId, [FromQuery]List<int> ingredientsId
                                        , [FromBody] Recipe recipeToCreate)
        {
            recipeToCreate.Country = _countryRepository.GetCountry(recipeToCreate.Country.Id);

            var statusCode = ValidateRecipe(authorsId, categoriesId, stepsId, ingredientsId, recipeToCreate);

            if (!ModelState.IsValid)
                return StatusCode(statusCode.StatusCode);

            if (!_recipeRepository.CreateRecipe(authorsId, categoriesId, stepsId, ingredientsId, recipeToCreate))
            {
                ModelState.AddModelError("", $"Something went wrong saving the recipe " +
                                            $"{recipeToCreate.Name}");
                return StatusCode(500, ModelState);
            }

            return CreatedAtRoute("GetRecipe", new { recipeId = recipeToCreate.Id }, recipeToCreate);
        }

        //api/recipes/recipeId?authId=1&authId=2&catId=1&catId=2&stepId=1&stepId=2&ingId=1&ingId=2
        [HttpPut("{recipeId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(422)]
        [ProducesResponseType(500)]
        public IActionResult UpdateRecipe([FromQuery]List<int> authorsId, [FromQuery] List<int> categoriesId, [FromQuery] List<int> stepsId, [FromQuery]List<int> ingredientsId
                                        , [FromBody] Recipe recipeToUpdate,
                                            int recipeId)
        {
            recipeToUpdate.Country = _countryRepository.GetCountry(recipeToUpdate.Country.Id);

            var statusCode = ValidateRecipe(authorsId, categoriesId, stepsId, ingredientsId, recipeToUpdate);

            if (recipeId != recipeToUpdate.Id)
                return BadRequest();

            if (!_recipeRepository.RecipeExists(recipeId))
                return NotFound();

            if (!ModelState.IsValid)
                return StatusCode(statusCode.StatusCode);

            if (!_recipeRepository.UpdateRecipe(authorsId, categoriesId, stepsId, ingredientsId, recipeToUpdate))
            {
                ModelState.AddModelError("", $"Something went wrong updating the recipe " +
                                            $"{recipeToUpdate.Name}");
                return StatusCode(500, ModelState);
            }

            return CreatedAtRoute("GetRecipe", new { recupeId = recipeToUpdate.Id }, recipeToUpdate);
        }

        //api/recipes/recipeId
        [HttpDelete("{recipeId}")]
        [ProducesResponseType(204)] //no content
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult DeleteRecipe(int recipeId)
        {
            if (!_recipeRepository.RecipeExists(recipeId))
                return NotFound();

            var reviewsToDelete = _reviewRepository.GetReviewsOfARecipe(recipeId);
            var recipeToDelete = _recipeRepository.GetRecipe(recipeId);

            if (!ModelState.IsValid)
                return BadRequest();

            if (!_reviewRepository.DeleteReviews(reviewsToDelete.ToList()))
            {
                ModelState.AddModelError("", $"Something went wrong deleting reviews");
                return StatusCode(500, ModelState);
            }

            if (!_recipeRepository.DeleteRecipe(recipeToDelete))
            {
                ModelState.AddModelError("", $"Something went wrong deleting recipe {recipeToDelete.Name}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}