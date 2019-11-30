using ERecipePresentation.DTO;
using System.Collections.Generic;

namespace ERcipePresentation.Repositories
{
    public interface IRecipeRepository
    {
        IEnumerable<RecipeDto> GetRecipes();

        RecipeDto GetRecipe(int recipeId);

        decimal GetRecipeRatingAverage(int recipeId);
    }
}