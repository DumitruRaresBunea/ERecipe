using ERecipe.Models;
using ERecipe.Services;
using System.Collections.Generic;
using System.Linq;

namespace ERecipe.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private RecipeDbContext _authorRepository;

        public AuthorRepository(RecipeDbContext authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public bool AuthorExists(int authorId)
        {
            return _authorRepository.Authors.Any(a => a.Id == authorId);
        }

        public Author GetAuthor(int authorId)
        {
            return _authorRepository.Authors.Where(a => a.Id == authorId).FirstOrDefault();
        }

        public ICollection<Author> GetAuthors()
        {
            return _authorRepository.Authors.OrderBy(a => a.FirstName).ToList();
        }

        public ICollection<Author> GetAuthorsOfARecipe(int recipeId)
        {
            return _authorRepository.RecipeAuthors.Where(r => r.Recipe.Id == recipeId).Select(a => a.Author).ToList();
        }

        public ICollection<Recipe> GetRecipesOfAAuthor(int authorId)
        {
            return _authorRepository.RecipeAuthors.Where(a => a.Author.Id == authorId).Select(r => r.Recipe).ToList();
        }
    }
}