using ERecipe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERecipe.Repositories
{
    public interface IRecipeRepository
    {
        ICollection<Recipe> GetRecipes();
        Recipe GetRecipe(int recipeId);
        decimal GetRecipeRatingAverage(int recipeId);
        bool RecipeExists(int recipeId);
    }
}
