using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERcipePresentation.Repositories;
using ERecipePresentation.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ERcipePresentation.Controllers
{
    public class ReviewersController : Controller
    {
        IReviewerRepository _reviewersRepository;

        public ReviewersController(IReviewerRepository reviewersRepository)
        {
            _reviewersRepository = reviewersRepository;
        }

        public IActionResult Index()
        {
            var reviewers = _reviewersRepository.GetReviewers();

            if (reviewers.Count() <= 0)
            {
                ViewBag.Message = "There was a problem retrieving reviewers from database or no reviewer exists";
            }
            return View(reviewers);
        }

        public IActionResult GetReviewerById(int reviewerId)
        {
            var reviewer = _reviewersRepository.GetReviewer(reviewerId);
            if (reviewer == null)
            {
                ModelState.AddModelError("", "Error getting a category");
                ViewBag.Message = $"There was a problem retrieving review with id {reviewerId} " +
                    $"from the database or no review with that id exists";
                reviewer = new ReviewerDto();
            }
            return View(reviewer);
        }
    }
}