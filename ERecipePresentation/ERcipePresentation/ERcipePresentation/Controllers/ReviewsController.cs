using ERcipePresentation.Repositories;
using ERcipePresentation.ViewModel;
using ERecipePresentation.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ERcipePresentation.Controllers
{
    public class ReviewsController : Controller
    {
        private IReviewRepository _reviewsRepository;
        private IReviewerRepository _reviewerRepository;

        public ReviewsController(IReviewRepository reviewsRepository, IReviewerRepository reviewerRepository)
        {
            _reviewsRepository = reviewsRepository;
            _reviewerRepository = reviewerRepository;
        }

        public IActionResult Index()
        {
            var review = _reviewsRepository.GetReviews();

            if (review.Count() <= 0)
            {
                ViewBag.Message = "There was a problem retrieving reviews from database or no review exists";
            }
            return View(review);
        }

        public IActionResult GetReviewById(int reviewId)
        {
            var review = _reviewsRepository.GetReview(reviewId);
            if (review == null)
            {
                ModelState.AddModelError("", "Error getting a review");
                ViewBag.Message = $"There was a problem retrieving review with id {reviewId} " +
                    $"from the database or no review with that id exists";
                review = new ReviewDto();
            }
            var reviewer = _reviewerRepository.GetReviewerOfAReview(reviewId);
            if(reviewer == null)
            {
                ModelState.AddModelError("", "Error getting the reviewer");
                ViewBag.Message += $"There was a problem retrieving reviewer" +
                    $"from the database";
                reviewer = new ReviewerDto();
            }

            var recipe = _reviewsRepository.GetRecipeOfAReview(reviewId);

            if (recipe == null)
            {
                ModelState.AddModelError("", "Error getting the recipe");
                ViewBag.Message += $"There was a problem retrieving recipe" +
                    $"from the database";
                recipe = new RecipeDto();
            }

            var reviewReviewerRecipeViewModel = new ReviewReviewerRecipeViewModel()
            {
                Recipe = recipe,
                Review = review,
                Reviewer = reviewer
            };
            return View(reviewReviewerRecipeViewModel);
        }
    }
}