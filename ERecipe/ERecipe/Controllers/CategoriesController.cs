using ERecipe.DTO;
using ERecipe.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ERecipe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : Controller
    {
        private ICategoryRepository _categoryRepository;
        private IRecipeRepository _recipeRepository;

        public CategoriesController(ICategoryRepository categoryRepository, IRecipeRepository recipeRepository)
        {
            _categoryRepository = categoryRepository;
            _recipeRepository = recipeRepository;
        }

        //api/categories
        [HttpGet]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CategoryDto>))]
        public IActionResult GetCategories()
        {
            var category = _categoryRepository.GetCategories();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var categotyDtos = new List<CategoryDto>();
            foreach (var country in category)
            {
                categotyDtos.Add(new CategoryDto
                {
                    Id = country.Id,
                    Name = country.Name
                });
            }
            return Ok(categotyDtos);
        }

        //api/categories/categoryId
        [HttpGet("{categoryId}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(CategoryDto))]
        public IActionResult GetCountry(int categoryId)
        {
            if (!_categoryRepository.CategoryExists(categoryId))
                return NotFound();

            var category = _categoryRepository.GetCategory(categoryId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var categoty = new CategoryDto()
            {
                Id = category.Id,
                Name = category.Name
            };

            return Ok(categoty);
        }

        //api/categories/recipes/recipeId
        [HttpGet("recipes/{recipeId}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CategoryDto>))]
        public IActionResult GetCategoriesOFRecipe(int recipeId)
        {
            if (!_recipeRepository.RecipeExists(recipeId))
                return NotFound();

            var categories = _categoryRepository.GetAllCategoriesForRecipe(recipeId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var categoriesDto = new List<CategoryDto>();

            foreach (var category in categories)
            {
                categoriesDto.Add(new CategoryDto()
                {
                    Id = category.Id,
                    Name = category.Name
                });
            }

            return Ok(categoriesDto);
        }

        //api/categories/categoryId/recipes
        [HttpGet("{categoryId}/recipes")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<RecipeDto>))]
        public IActionResult GetAllRecipesFromACategory(int categoryId)
        {
            if (!_categoryRepository.CategoryExists(categoryId))
                return NotFound();

            var recipes = _categoryRepository.GetRecipesOfCategory(categoryId);

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

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
    }
}
