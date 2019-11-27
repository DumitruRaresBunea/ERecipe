using ERecipe.DTO;
using ERecipe.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ERecipe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : Controller
    {
        private IAuthorRepository _authorsRepository;
        private IRecipeRepository _recipeRepository;

        public AuthorsController(IAuthorRepository authorsRepository, IRecipeRepository recipeRepository)
        {
            _authorsRepository = authorsRepository;
            _recipeRepository = recipeRepository;
        }

        //api/authors
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<AuthorDto>))]
        [ProducesResponseType(400)]
        public IActionResult GetAuthors()
        {
            var authors = _authorsRepository.GetAuthors();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var authorDto = new List<AuthorDto>();

            foreach (var author in authors)
            {
                authorDto.Add(new AuthorDto
                {
                    Id = author.Id,
                    FirstName = author.FirstName,
                    LastName = author.LastName,
                    Email = author.Email,
                    PhoneNumber = author.PhoneNumber
                });
            }
            return Ok(authorDto);
        }

        //api/authors/authorId
        [HttpGet("{authorId}")]
        [ProducesResponseType(200, Type = typeof(AuthorDto))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetAuthor(int authorId)
        {
            if (!_authorsRepository.AuthorExists(authorId))
                return NotFound();

            var author = _authorsRepository.GetAuthor(authorId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var authorDto = new AuthorDto()
            {
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName,
                Email = author.Email,
                PhoneNumber = author.PhoneNumber
            };

            return Ok(authorDto);
        }

        //api/authors/authorId/recipes
        [HttpGet("{authorId}/recipes")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<RecipeDto>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetRecipeByAuthor(int authorId)
        {
            if (!_authorsRepository.AuthorExists(authorId)) 
                return NotFound();

            var recipes = _authorsRepository.GetRecipesOfAAuthor(authorId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var recipesDto = new List<RecipeDto>();

            foreach(var recipe in recipes)
            {
                recipesDto.Add(new RecipeDto()
                { 
                    Id = recipe.Id,
                    Description = recipe.Description,
                    Name = recipe.Name
                });
            }

            return Ok(recipesDto);
        }

        //api/authors/recipes/recipeId
        [HttpGet("recipes/{recipeId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<AuthorDto>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetAuthorsOfARecipe(int recipeId)
        {
            if (!_recipeRepository.RecipeExists(recipeId))
                return NotFound();

            var authors = _authorsRepository.GetAuthorsOfARecipe(recipeId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var authorsDto = new List<AuthorDto>();

            foreach (var author in authors)
            {
                authorsDto.Add(new AuthorDto()
                {
                    Id = author.Id,
                    FirstName=author.FirstName,
                    LastName=author.LastName,
                    Email =author.Email,
                    PhoneNumber=author.PhoneNumber
                }) ;
            }

            return Ok(authorsDto);
        }
    }
}