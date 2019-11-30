using ERecipePresentation.DTO;
using System.Collections.Generic;

namespace ERcipePresentation.Repositories
{
    public interface IIngredientRepository
    {
        IEnumerable<IngredientDto> GetIngredients();

        IngredientDto GetIngredient(int ingredientId);

        IEnumerable<IngredientDto> GetIngredientsOfARecipe(int recipeId);

        RecipeDto GetRecipeOfAIngredient(int ingredientId);
    }
}