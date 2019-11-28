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

        public bool CreateRecipe(List<int> authorsId, List<int> categoriesId, List<int> stepsId, List<int> ingredientsId, Recipe recipe)
        {
            var authors = _recipeDbContext.Authors.Where(a => authorsId.Contains(a.Id)).ToList();
            var categories = _recipeDbContext.Categories.Where(c => categoriesId.Contains(c.Id)).ToList();
            var steps = _recipeDbContext.Steps.Where(s => stepsId.Contains(s.Id)).ToList();
            var ingredients = _recipeDbContext.Ingredients.Where(i => ingredientsId.Contains(i.Id)).ToList();

            foreach (var author in authors)
            {
                var recipeAuthor = new RecipeAuthor()
                {
                    Author = author,
                    Recipe = recipe
                };
                _recipeDbContext.Add(recipeAuthor);
            }

            foreach (var category in categories)
            {
                var recipeCategories = new RecipeCategory()
                {
                    Category = category,
                    Recipe = recipe
                };
                _recipeDbContext.Add(recipeCategories);
            }

            foreach (var ingredient in ingredients)
            {
                var recipeIngredients = new RecipeIngredient()
                {
                    Ingredient = ingredient,
                    Recipe = recipe
                };
                _recipeDbContext.Add(recipeIngredients);
            }

            foreach (var step in steps)
            {
                var s = new Step()
                {
                    Description = step.Description,
                    Recipe = recipe
                };
                _recipeDbContext.Add(s);
            }

            return Save();
        }

        public bool DeleteRecipe(Recipe recipe)
        {
            var stepsToDelete = _recipeDbContext.Steps.Where(s => s.Recipe.Id == recipe.Id);
            var ingredientAuthorsToDelete = _recipeDbContext.RecipeIngredients.Where(i => i.RecipeId == recipe.Id);

            _recipeDbContext.RemoveRange(ingredientAuthorsToDelete);
            _recipeDbContext.RemoveRange(stepsToDelete);

            _recipeDbContext.Remove(recipe);
            return Save();
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

        public bool Save()
        {
            var saved = _recipeDbContext.SaveChanges();
            return saved >= 0 ? true : false;
        }

        public bool UpdateRecipe(List<int> authorsId, List<int> categoriesId, List<int> stepsId, List<int> ingredientsId, Recipe recipe)
        {
            var authors = _recipeDbContext.Authors.Where(a => authorsId.Contains(a.Id)).ToList();
            var categories = _recipeDbContext.Categories.Where(c => categoriesId.Contains(c.Id)).ToList();
            var steps = _recipeDbContext.Steps.Where(s => stepsId.Contains(s.Id)).ToList();
            var ingredients = _recipeDbContext.Ingredients.Where(i => ingredientsId.Contains(i.Id)).ToList();

            var recipeAuthorsToDelete = _recipeDbContext.RecipeAuthors.Where(r => r.RecipeId == recipe.Id);
            var categoryAuthorsToDelete = _recipeDbContext.RecipeCategories.Where(c => c.RecipeId == recipe.Id);
            var ingredientAuthorsToDelete = _recipeDbContext.RecipeIngredients.Where(i => i.RecipeId == recipe.Id);
            var stepsToDelete = _recipeDbContext.Steps.Where(s => s.Recipe.Id == recipe.Id);

            _recipeDbContext.RemoveRange(recipeAuthorsToDelete);
            _recipeDbContext.RemoveRange(categoryAuthorsToDelete);
            _recipeDbContext.RemoveRange(ingredientAuthorsToDelete);
            _recipeDbContext.RemoveRange(stepsToDelete);

            foreach (var author in authors)
            {
                var recipeAuthor = new RecipeAuthor()
                {
                    Author = author,
                    Recipe = recipe
                };
                _recipeDbContext.Add(recipeAuthor);
            }

            foreach (var category in categories)
            {
                var recipeCategories = new RecipeCategory()
                {
                    Category = category,
                    Recipe = recipe
                };
                _recipeDbContext.Add(recipeCategories);
            }

            foreach (var ingredient in ingredients)
            {
                var recipeIngredients = new RecipeIngredient()
                {
                    Ingredient = ingredient,
                    Recipe = recipe
                };
                _recipeDbContext.Add(recipeIngredients);
            }

            foreach (var step in steps)
            {
                var s = new Step()
                {
                    Description = step.Description,
                    Recipe = recipe
                };
                _recipeDbContext.Add(s);
            }

            return Save();
        }
    }
}