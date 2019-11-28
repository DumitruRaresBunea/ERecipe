using ERecipe.Models;
using System.Collections.Generic;

namespace ERecipe.Repositories
{
    public interface IStepRepository
    {
        ICollection<Step> GetSteps();

        Step GetStep(int stepId);

        ICollection<Step> GetStepsForARecipe(int recipeId);

        Recipe GetRecipeOfAStep(int stepId);

        bool StepExists(int stepId);

        bool CreateStep(Step step);

        bool UpdateStep(Step step);

        bool DeleteStep(Step step);

        bool Save();
    }
}