using ERecipe.Models;
using ERecipe.Services;
using System.Collections.Generic;
using System.Linq;

namespace ERecipe.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private RecipeDbContext _categoryContext;

        public CategoryRepository(RecipeDbContext categotyContext)
        {
            _categoryContext = categotyContext;
        }

        public bool CountryExists(int categoryId)
        {
            return _categoryContext.Categories.Any(c => c.Id == categoryId);
        }

        public ICollection<Category> GetCategories()
        {
            return _categoryContext.Categories.OrderBy(c => c.Name).ToList();
        }

        public ICollection<Category> GetAllCategoriesForRecipe(int recipeId)
        {
            return _categoryContext.RecipeCategories.Where(r => r.RecipeId == recipeId).Select(c => c.Category).ToList();
        }

        public Category GetCategory(int categoryId)
        {
            return _categoryContext.Categories.Where(c => c.Id == categoryId).FirstOrDefault();
        }

        public ICollection<Recipe> GetRecipesOfCategory(int categoryId)
        {
            return _categoryContext.RecipeCategories.Where(c => c.CategoryId == categoryId).Select(r => r.Recipe).ToList();
        }
    }
}