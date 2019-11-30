using ERecipe.Models;
using System.Collections.Generic;

namespace ERecipe.Repositories
{
    public interface IRecipeRepository
    {
        ICollection<Recipe> GetRecipes();

        Recipe GetRecipe(int recipeId);

        decimal GetRecipeRatingAverage(int recipeId);

        bool RecipeExists(int recipeId);

        bool CreateRecipe(List<int> authorsId, List<int> categoriesId, List<int> stepsId, List<int> ingredientsId, Recipe recipe);

        bool UpdateRecipe(List<int> authorsId, List<int> categoriesId, List<int> stepsId, List<int> ingredientsId, Recipe recipe);

        bool DeleteRecipe(Recipe recipe);

        bool Save();
    }
}