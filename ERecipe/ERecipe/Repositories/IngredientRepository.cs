using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERecipe.Models;
using ERecipe.Services;

namespace ERecipe.Repositories
{
    public class IngredientRepository : IIngredientRepository
    {
        private RecipeDbContext _ingredientContext;

        public IngredientRepository(RecipeDbContext ingredientContext)
        {
            _ingredientContext = ingredientContext;
        }

        public Ingredient GetIngredient(int ingredientId)
        {
            return _ingredientContext.Ingredients.Where(c => c.Id == ingredientId).FirstOrDefault();

        }

        public ICollection<Ingredient> GetIngredients()
        {
            return _ingredientContext.Ingredients.OrderBy(c => c.Name).ToList();
        }

        public ICollection<Ingredient> GetIngredientsOfARecipe(int recipeId)
        {
            return _ingredientContext.RecipeIngredients.Where(i => i.RecipeId == recipeId).Select(r => r.Ingredient).ToList();

        }

        public Recipe GetRecipeOfAIngredient(int ingredientId)
        {
            return _ingredientContext.Recipes.Where(r => r.Id == ingredientId).FirstOrDefault();
        }

        public bool IngredientExists(int ingredientId)
        {
            return _ingredientContext.Ingredients.Any(c => c.Id == ingredientId);
        }
    }
}
