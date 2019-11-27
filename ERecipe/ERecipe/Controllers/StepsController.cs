using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERecipe.DTO;
using ERecipe.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ERecipe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StepsController : Controller
    {
        private IStepRepository _stepRepository;
        private IRecipeRepository _recipeRepository;

        public StepsController(IStepRepository stepRepository, IRecipeRepository recipeRepository)
        {
            _stepRepository = stepRepository;
            _recipeRepository = recipeRepository;
        }

        //api/steps
        [HttpGet]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<StepDto>))]
        public IActionResult GetSteps()
        {
            var steps = _stepRepository.GetSteps().ToList();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var stepsDto = new List<StepDto>();
            foreach (var step in steps)
            {
                stepsDto.Add(new StepDto
                {
                  Id=step.Id
                  ,Description=step.Description
                });
            }
            return Ok(stepsDto);
        }

        //api/steps/stepId
        [HttpGet("{stepId}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(StepDto))]
        public IActionResult GetStep(int stepId)
        {
            if (!_stepRepository.StepExists(stepId))
                return NotFound();

            var step = _stepRepository.GetStep(stepId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var stepDto = new StepDto()
            {
                Id = step.Id,
                Description = step.Description
            };

            return Ok(stepDto);
        }

        //api/steps/recipes/recipeId
        [HttpGet("recipes/{recipeId}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<StepDto>))]
        public IActionResult GetIngredientssOFRecipe(int recipeId)
        {
            if (!_recipeRepository.RecipeExists(recipeId))
                return NotFound();

            var steps = _stepRepository.GetStepsForARecipe(recipeId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var stepsDto = new List<StepDto>();

            foreach (var step in steps)
            {
                stepsDto.Add(new StepDto()
                {
                    Id = step.Id,
                    Description = step.Description
                });
            }

            return Ok(stepsDto);
        }

        //api/steps/stepId/recipes
        [HttpGet("{stepId}/recipes")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(StepDto))]
        public IActionResult GetRecipeFromIngredient(int stepId)
        {
            if (!_stepRepository.StepExists(stepId))
                return NotFound();

            var recipe = _stepRepository.GetRecipeOfAStep(stepId);

            if (!ModelState.IsValid)
                return BadRequest();

            var recipeDto = new RecipeDto()
            {
                Id = recipe.Id,
                Name = recipe.Name,
                Description = recipe.Description,
                PublishDate = recipe.PublishDate
            };

            return Ok(recipeDto);
        }
    }
}