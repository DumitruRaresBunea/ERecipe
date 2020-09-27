using ERecipe.DataContext.Models;
using ERecipe.Services.Models;
using ERecipe.Services.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;

namespace Services.Services
{
    public class AuthorService
        : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IRecipeRepository _recipeRepository;

        public AuthorService(IAuthorRepository authorRepository, IRecipeRepository recipeRepository)
        {
            _authorRepository = authorRepository;
            _recipeRepository = recipeRepository;
        }

        public IActionResult CreateAuthor(Author author, ModelStateDictionary state)
        {
            if (author == null)
                return new BadRequestObjectResult(state);

            if (!state.IsValid)
                return new BadRequestObjectResult(state);

            if (!_authorRepository.CreateAuthor(author))
            {
                state.AddModelError("", $"Something went wrong saving the author " +
                                            $"{author.FirstName} {author.LastName}");
                return new ObjectResult(state)
                {
                    StatusCode = 500
                }
                ;
            }

            return new CreatedAtRouteResult("GetAuthor", new { authorId = author.Id }, author);
        }

        public IActionResult DeleteAuthor(Author author, ModelStateDictionary state)
        {
            throw new NotImplementedException();
        }

        public IActionResult GetAuthor(int authorId, ModelStateDictionary state)
        {
            throw new NotImplementedException();
        }

        public IActionResult GetAuthors(ModelStateDictionary state)
        {
            var authors = _authorRepository.GetAuthors();
            if (!state.IsValid)
                return new BadRequestObjectResult(state);

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
            return new OkObjectResult(authorDto);
        }

        public IActionResult GetAuthorsOfARecipe(int recipeId, ModelStateDictionary state)
        {
            throw new NotImplementedException();
        }

        public IActionResult GetRecipesOfAAuthor(int authorId, ModelStateDictionary state)
        {
            throw new NotImplementedException();
        }

        public IActionResult UpdateAuthor(Author author, ModelStateDictionary state)
        {
            throw new NotImplementedException();
        }
    }
}