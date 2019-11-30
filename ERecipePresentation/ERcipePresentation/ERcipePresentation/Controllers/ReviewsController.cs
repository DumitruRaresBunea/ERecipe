using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERcipePresentation.Repositories;
using ERecipePresentation.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ERcipePresentation.Controllers
{
    public class ReviewsController : Controller
    {
        IReviewRepository _reviewsRepository;

        public ReviewsController(IReviewRepository reviewsRepository)
        {
            _reviewsRepository = reviewsRepository;
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
                ModelState.AddModelError("", "Error getting a category");
                ViewBag.Message = $"There was a problem retrieving review with id {reviewId} " +
                    $"from the database or no review with that id exists";
                review = new ReviewDto();
            }
            return View(review);
        }
    }
}