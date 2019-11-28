using ERecipe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
