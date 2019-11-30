using ERecipePresentation.DTO;
using System.Collections.Generic;

namespace ERcipePresentation.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<CategoryDto> GetCategories();

        CategoryDto GetCategory(int categoryId);

        IEnumerable<CategoryDto> GetAllCategoriesForRecipe(int recipeId);

        IEnumerable<RecipeDto> GetRecipesOfCategory(int categoryId);
    }
}