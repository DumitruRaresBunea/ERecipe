using ERecipePresentation.DTO;
using System.Collections.Generic;

namespace ERcipePresentation.Repositories
{
    public interface IAuthorRepository
    {
        IEnumerable<AuthorDto> GetAuthors();

        AuthorDto GetAuthor(int authorId);

        IEnumerable<AuthorDto> GetAuthorsOfARecipe(int recipeId);

        IEnumerable<RecipeDto> GetRecipesOfAAuthor(int authorId);
    }
}