using ERecipe.DataContext.Models;
using ERecipe.Services.Models;
using ERecipe.Services.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;


namespace ERecipe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StepsController : Controller
    {
        private readonly IStepRepository _stepRepository;
        private readonly IRecipeRepository _recipeRepository;

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
        [HttpGet("{stepId}", Name = "GetStep")]
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
        public IActionResult GetStepsOFRecipe(int recipeId)
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
        public IActionResult GetRecipeFromStep(int stepId)
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

        //api/steps
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Step))]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult CreateStep([FromBody]Step stepToCreate)
        {
            if (stepToCreate == null)
                return BadRequest(ModelState);

          

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_stepRepository.CreateStep(stepToCreate))
            {
                ModelState.AddModelError("", $"Something went wrong saving this step");
                return StatusCode(500, ModelState);
            }

            return CreatedAtRoute("GetStep", new { countryId = stepToCreate.Id }, stepToCreate);
        }

        //api/steps/stepId
        [HttpPut("{stepId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(422)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public IActionResult UpdateStep(int stepId, [FromBody]Step updatedStepInfo)
        {
            if (updatedStepInfo == null)
                return BadRequest(ModelState);

            if (stepId != updatedStepInfo.Id)
                return BadRequest(ModelState);

           

         

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_stepRepository.UpdateStep(updatedStepInfo))
            {
                ModelState.AddModelError("", $"Something went wrong updating this step");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
        //api/steps/stepId
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(422)]
        [ProducesResponseType(409)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        [HttpDelete("{stepId}")]
        public IActionResult DeleteCountry(int stepId)
        {
            if (!_stepRepository.StepExists(stepId))
                return NotFound();

            var stepToDelete = _stepRepository.GetStep(stepId);

            if (_stepRepository.GetRecipeOfAStep(stepId)!=null)
            {
                ModelState.AddModelError("", $"Step cannot be deleted because there is a recipe linked to it");
                return StatusCode(409, ModelState); //409 = conflict
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_stepRepository.DeleteStep(stepToDelete))
            {
                ModelState.AddModelError("", $"Something went wrong deleting this step");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}