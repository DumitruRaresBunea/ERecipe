using ERecipe.Models;
using System.Collections.Generic;

namespace ERecipe.Repositories
{
    public interface IAuthorRepository
    {
        ICollection<Author> GetAuthors();

        Author GetAuthor(int authorId);

        ICollection<Author> GetAuthorsOfARecipe(int recipeId);

        ICollection<Recipe> GetRecipesOfAAuthor(int authorId);

        bool AuthorExists(int authorId);

        bool CreateAuthor(Author author);

        bool UpdateAuthor(Author author);

        bool DeleteAuthor(Author author);

        bool Save();
    }
}