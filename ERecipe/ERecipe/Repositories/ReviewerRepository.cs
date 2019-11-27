using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERecipe.Models;
using ERecipe.Services;

namespace ERecipe.Repositories
{
    public class ReviewerRepository : IReviewerRepository
    {
        private RecipeDbContext _reviewerContext;

        public ReviewerRepository(RecipeDbContext reviewerContext)
        {
            _reviewerContext = reviewerContext;
        }

        public Reviewer GetReviewer(int reviewerId)
        {
            return _reviewerContext.Reviewers.Where(r => r.Id == reviewerId).FirstOrDefault();

        }

        public Reviewer GetReviewerOfAReview(int reviewId)
        {
            var reviewerId = _reviewerContext.Reviews.Where(r => r.Id == reviewId).Select(r => r.Reviewer.Id).FirstOrDefault();
            return _reviewerContext.Reviewers.Where(r => r.Id == reviewerId).FirstOrDefault();

        }

        public ICollection<Reviewer> GetReviewers()
        {
            return _reviewerContext.Reviewers.OrderBy(r => r.FirstName).ToList();

        }

        public ICollection<Review> GetReviewsByReviewer(int reviewerId)
        {
            return _reviewerContext.Reviews.Where(r => r.Id == reviewerId).ToList();
        }

        public bool ReviewerExists(int reviewerId)
        {
            return _reviewerContext.Reviewers.Any(r => r.Id == reviewerId);
        }
    }
}
