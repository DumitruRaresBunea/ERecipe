using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERcipePresentation.Repositories;
using ERcipePresentation.ViewModel;
using ERecipePresentation.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ERcipePresentation.Controllers
{
    public class ReviewersController : Controller
    {
        IReviewerRepository _reviewersRepository;
        IReviewRepository _reviewRepository;

        public ReviewersController(IReviewerRepository reviewersRepository, IReviewRepository reviewRepository)
        {
            _reviewersRepository = reviewersRepository;
            _reviewRepository = reviewRepository;
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

            var reviews = _reviewersRepository.GetReviewsByReviewer(reviewerId);
            if(reviews.Count()<=0)
            {
                ViewBag.ReviewMessage = $"Reviewer {reviewer.FirstName} {reviewer.LastName} has no reviews";
            }
            IDictionary<ReviewDto, RecipeDto> reviewAndRecipe = new Dictionary<ReviewDto, RecipeDto>();

            foreach(var review in reviews)
            {
                var recipe = _reviewRepository.GetRecipeOfAReview(review.Id);
                reviewAndRecipe.Add(review, recipe);
            }

            var revieewReviewsRecipe = new ReviewerReviewsRecipeViewModel
            {
                Reviewer = reviewer,
                ReviewRecipe = reviewAndRecipe
            };
            return View(revieewReviewsRecipe);
        }
    }
}