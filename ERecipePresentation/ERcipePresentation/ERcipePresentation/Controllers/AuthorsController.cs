using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERcipePresentation.Repositories;
using ERecipePresentation.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ERcipePresentation.Controllers
{
    public class AuthorsController : Controller
    {
        IAuthorRepository _authorRepository;

        public AuthorsController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
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
            return View(author);
        }
    }
}