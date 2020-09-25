using ERecipe.DataContext;
using ERecipe.DataContext.Models;
using System.Collections.Generic;
using System.Linq;

namespace ERecipe.Services.Repositories
{
    public class StepRepository : IStepRepository
    {
        private RecipeDbContext _stepContext;

        public StepRepository(RecipeDbContext stepContext)
        {
            _stepContext = stepContext;
        }

        public bool CreateStep(Step step)
        {
            _stepContext.Add(step);
            return Save();
        }

        public bool DeleteStep(Step step)
        {
            _stepContext.Remove(step);
            return Save();
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

        public bool Save()
        {
            var saved = _stepContext.SaveChanges();
            return saved >= 0 ? true : false;
        }

        public bool StepExists(int stepId)
        {
            return _stepContext.Steps.Any(s => s.Id == stepId);
        }

        public bool UpdateStep(Step step)
        {
            _stepContext.Update(step);
            return Save();
        }
    }
}