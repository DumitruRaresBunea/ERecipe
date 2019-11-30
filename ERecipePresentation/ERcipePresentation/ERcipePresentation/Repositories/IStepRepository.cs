using ERecipePresentation.DTO;
using System.Collections.Generic;

namespace ERcipePresentation.Repositories
{
    public interface IStepRepository
    {
        IEnumerable<StepDto> GetSteps();

        StepDto GetStep(int stepId);

        IEnumerable<StepDto> GetStepsForARecipe(int recipeId);

        RecipeDto GetRecipeOfAStep(int stepId);
    }
}