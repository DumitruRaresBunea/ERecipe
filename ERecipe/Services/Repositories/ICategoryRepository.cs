using ERecipe.DataContext.Models;
using System.Collections.Generic;

namespace ERecipe.Services.Repositories
{
    public interface ICategoryRepository
    {
        ICollection<Category> GetCategories();

        Category GetCategory(int categoryId);

        ICollection<Category> GetAllCategoriesForRecipe(int recipeId);

        ICollection<Recipe> GetRecipesOfCategory(int categoryId);

        bool CategoryExists(int categoryId);

        bool IsDupliocateCategoryName(int categoryId, string categoryName);

        bool CreateCategory(Category category);

        bool UpdateCategory(Category category);

        bool DeleteCategory(Category category);

        bool Save();
    }
}
