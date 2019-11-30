using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERcipePresentation.Repositories;
using ERecipePresentation.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ERcipePresentation.Controllers
{
    public class StepsController : Controller
    {
        IStepRepository _stepRepository;

        public StepsController(IStepRepository stepRepository)
        {
            _stepRepository = stepRepository;
        }

        public IActionResult Index()
        {
            var steps = _stepRepository.GetSteps();

            if (steps.Count() <= 0)
            {
                ViewBag.Message = "There was a problem retrieving steps from database or no step exists";
            }
            return View(steps);
        }

        public IActionResult GetStepById(int stepId)
        {
            var step = _stepRepository.GetStep(stepId);
            if (step == null)
            {
                ModelState.AddModelError("", "Error getting a category");
                ViewBag.Message = $"There was a problem retrieving step with id {stepId} " +
                    $"from the database or no step with that id exists";
                step = new StepDto();
            }
            return View(step);
        }
    }
}