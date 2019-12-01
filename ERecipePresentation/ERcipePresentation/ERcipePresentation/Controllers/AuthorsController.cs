using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERcipePresentation.Repositories;
using ERcipePresentation.ViewModel;
using ERecipePresentation.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ERcipePresentation.Controllers
{
    public class AuthorsController : Controller
    {
        IAuthorRepository _authorRepository;
        ICategoryRepository _categoryRepository;
        ICountryRepository _countryRepository;

        public AuthorsController(IAuthorRepository authorRepository, ICategoryRepository categoryRepository, ICountryRepository countryRepository)
        {
            _authorRepository = authorRepository;
            _categoryRepository = categoryRepository;
            _countryRepository = countryRepository;
        }

        public IActionResult Index()
        {
            var authors = _authorRepository.GetAuthors();

            if (authors.Count() <= 0)
            {
                ViewBag.Message = "There was a problem retrieving authors from database or no author exists";
            }
            return View(authors);
        }

        public IActionResult GetAuthorById(int authorId)
        {
            var author = _authorRepository.GetAuthor(authorId);
            if (author == null)
            {
                ModelState.AddModelError("", "Error getting a category");
                ViewBag.Message = $"There was a problem retrieving author with id {authorId} " +
                    $"from the database or no author with that id exists";
                author = new AuthorDto();
            }

            var recipeCategories = new Dictionary<RecipeDto, IEnumerable<CategoryDto>>();

            var recipes = _authorRepository.GetRecipesOfAAuthor(authorId);

            if (recipes.Count() <= 0)
            {
                ViewBag.Message += $"No recipes for author {author.FirstName} {author.LastName} exist.";
            }

            foreach(var recipe in recipes)
            {
                var categories = _categoryRepository.GetAllCategoriesForRecipe(recipe.Id);
                recipeCategories.Add(recipe, categories);
            }

            var authorRecipeCategoriesViewModel = new AuthorRecipeCategoriesViewModel
            {
                Author = author,
                RecipeCategories = recipeCategories
            };

            return View(authorRecipeCategoriesViewModel);
        }
    }
}