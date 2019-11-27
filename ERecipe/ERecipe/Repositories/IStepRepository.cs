using ERecipe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERecipe.Repositories
{
    public interface IStepRepository
    {
        ICollection<Step> GetSteps();
        Step GetStep(int stepId);
        ICollection<Step> GetStepsForARecipe(int recipeId);
        Recipe GetRecipeOfAStep(int stepId);
        bool StepExists(int stepId);
    }
}
