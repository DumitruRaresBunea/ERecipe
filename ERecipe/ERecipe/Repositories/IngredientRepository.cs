using ERecipe.Models;
using ERecipe.Services;
using System.Collections.Generic;
using System.Linq;

namespace ERecipe.Repositories
{
    public class IngredientRepository : IIngredientRepository
    {
        private RecipeDbContext _ingredientContext;

        public IngredientRepository(RecipeDbContext ingredientContext)
        {
            _ingredientContext = ingredientContext;
        }

        public bool CreateIngredient(Ingredient ingredient)
        {
            _ingredientContext.Add(ingredient);
            return Save();
        }

        public bool DeleteIngredient(Ingredient ingredient)
        {
            _ingredientContext.Remove(ingredient);
            return Save();
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
            return _ingredientContext.RecipeIngredients.Where(i => i.IngredientId == ingredientId).Select(r => r.Recipe).FirstOrDefault();
        }

        public bool IngredientExists(int ingredientId)
        {
            return _ingredientContext.Ingredients.Any(c => c.Id == ingredientId);
        }

        public bool Save()
        {
            var saved = _ingredientContext.SaveChanges();
            return saved >= 0 ? true : false;
        }

        public bool UpdateIngredient(Ingredient ingredient)
        {
            _ingredientContext.Update(ingredient);
            return Save();
        }
    }
}