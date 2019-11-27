using ERecipe.Models;
using ERecipe.Services;
using System.Collections.Generic;
using System.Linq;

namespace ERecipe.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private RecipeDbContext _recipeDbContext;

        public RecipeRepository(RecipeDbContext recipeDbContext)
        {
            _recipeDbContext = recipeDbContext;
        }

        public Recipe GetRecipe(int recipeId)
        {
            return _recipeDbContext.Recipes.Where(r => r.Id == recipeId).FirstOrDefault();
        }

        public decimal GetRecipeRatingAverage(int recipeId)
        {
            var reviews = _recipeDbContext.Reviews.Where(r => r.ReviewdRecipe.Id == recipeId);
            if (reviews.Count() <= 0)
                return 0;

            return ((decimal)reviews.Sum(r => r.Rating) / reviews.Count());
        }

        public ICollection<Recipe> GetRecipes()
        {
            return _recipeDbContext.Recipes.OrderBy(r => r.Name).ToList();
        }

        public bool RecipeExists(int recipeId)
        {
            return _recipeDbContext.Recipes.Any(r => r.Id == recipeId);
        }
    }
}