using ERecipe.DataContext.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Services.Services
{
    public interface IAuthorService
    {
        IActionResult GetAuthors(ModelStateDictionary state);

        IActionResult GetAuthor(int authorId, ModelStateDictionary state);

        IActionResult GetAuthorsOfARecipe(int recipeId, ModelStateDictionary state);

        IActionResult GetRecipesOfAAuthor(int authorId, ModelStateDictionary state);


        IActionResult CreateAuthor(Author author, ModelStateDictionary state);

        IActionResult UpdateAuthor(Author author, ModelStateDictionary state);

        IActionResult DeleteAuthor(Author author, ModelStateDictionary state);
    }
}