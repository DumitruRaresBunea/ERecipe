using ERecipe.DataContext.Models;
using System.Collections.Generic;

namespace ERecipe.Services.Repositories
{
    public interface IIngredientRepository
    {
        ICollection<Ingredient> GetIngredients();
        Ingredient GetIngredient(int ingredientId);
        ICollection<Ingredient> GetIngredientsOfARecipe(int recipeId);
        Recipe GetRecipeOfAIngredient(int ingredientId);
        bool IngredientExists(int ingredientId);

        bool CreateIngredient(Ingredient ingredient);

        bool UpdateIngredient(Ingredient ingredient);

        bool DeleteIngredient(Ingredient ingredient);

        bool Save();
    }
}
