using ERecipe.DTO;
using ERecipe.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ERecipe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : Controller
    {
        private ICountryRepository _countryRepository;

        public CountriesController(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        //api/countries
        [HttpGet]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CountryDTO>))]
        public IActionResult GetCountries()
        {
            var countries = _countryRepository.GetCountries().ToList();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var countriesDto = new List<CountryDTO>();
            foreach (var country in countries)
            {
                countriesDto.Add(new CountryDTO
                {
                    Id = country.Id,
                    Name = country.Name
                });
            }
            return Ok(countriesDto);
        }

        //api/countries/countryId
        [HttpGet("{countryId}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(CountryDTO))]
        public IActionResult GetCountry(int countryId)
        {
            if (!_countryRepository.CountryExists(countryId))
                return NotFound();

            var country = _countryRepository.GetCountry(countryId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var countryDto = new CountryDTO()
            {
                Id = country.Id,
                Name = country.Name
            };

            return Ok(countryDto);
        }

        //api/countries/recipes/recipeId
        [HttpGet("recipes/{recipeId}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(CountryDTO))]
        public IActionResult GetCountryOfRecipe(int recipeId)
        {
            //TO DD -validate if autho exists

            var country = _countryRepository.GetCountryOfARecipe(recipeId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var countryDto = new CountryDTO()
            {
                Id = country.Id,
                Name = country.Name
            };

            return Ok(countryDto);
        }

        //api/countries/countryId/recipes
        [HttpGet("{countryId}/recipes")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<RecipeDto>))]
        public IActionResult GetRecipesFromCountry(int countryId)
        {
            if (!_countryRepository.CountryExists(countryId))
                return NotFound();

            var recipes = _countryRepository.GetRecipesFromCountry(countryId);

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
                    PublishDate =recipe.PublishDate
                });
            }

            return Ok(recipesDto);
        }
    }
}