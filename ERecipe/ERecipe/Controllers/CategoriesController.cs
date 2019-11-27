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

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
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
            if (!_categoryRepository.CountryExists(categoryId))
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
        public IActionResult GetCountryOfRecipe(int recipeId)
        {
            //TO DD -validate if autho exists

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

        //To Do GetAllBooksForCategory
    }
}
