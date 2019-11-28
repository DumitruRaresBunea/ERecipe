using ERecipe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERecipe.Repositories
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
