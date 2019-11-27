using ERecipe.Models;
using ERecipe.Services;
using System.Collections.Generic;
using System.Linq;

namespace ERecipe.Repositories
{
    public class StepRepository : IStepRepository
    {
        private RecipeDbContext _stepContext;

        public StepRepository(RecipeDbContext stepContext)
        {
            _stepContext = stepContext;
        }

        public Recipe GetRecipeOfAStep(int stepId)
        {
            var recipeId = _stepContext.Steps.Where(s => s.Id == stepId).Select(r => r.Recipe.Id).FirstOrDefault();
            return _stepContext.Recipes.Where(r => r.Id == recipeId).FirstOrDefault();
        }

        public Step GetStep(int stepId)
        {
            return _stepContext.Steps.Where(s => s.Id == stepId).FirstOrDefault();
        }

        public ICollection<Step> GetSteps()
        {
            return _stepContext.Steps.OrderBy(s => s.Id).ToList();
        }

        public ICollection<Step> GetStepsForARecipe(int recipeId)
        {
            return _stepContext.Steps.Where(s => s.Recipe.Id == recipeId).ToList();
        }

        public bool StepExists(int stepId)
        {
            return _stepContext.Steps.Any(s => s.Id == stepId);
        }
    }
}