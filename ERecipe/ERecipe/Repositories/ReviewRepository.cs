using ERecipe.Models;
using ERecipe.Services;
using System.Collections.Generic;
using System.Linq;

namespace ERecipe.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private RecipeDbContext _reviewContext;

        public ReviewRepository(RecipeDbContext reviewContext)
        {
            _reviewContext = reviewContext;
        }

        public bool CreateReview(Review review)
        {
            _reviewContext.Add(review);
            return Save();
        }

        public bool DeleteReview(Reviewer review)
        {
            _reviewContext.Remove(review);
            return Save();
        }

        public Recipe GetRecipeOfAReview(int reviewId)
        {
            var recipeId = _reviewContext.Reviews.Where(r => r.Id == reviewId).Select(r => r.ReviewdRecipe.Id).FirstOrDefault();
            return _reviewContext.Recipes.Where(r => r.Id == recipeId).FirstOrDefault();
        }

        public Review GetReview(int reviewId)
        {
            return _reviewContext.Reviews.Where(r => r.Id == reviewId).FirstOrDefault();
        }

        public ICollection<Review> GetReviews()
        {
            return _reviewContext.Reviews.OrderBy(r => r.Rating).ToList();
        }

        public ICollection<Review> GetReviewsOfARecipe(int recipeId)
        {
            return _reviewContext.Reviews.Where(r => r.ReviewdRecipe.Id == recipeId).ToList();
        }

        public bool ReviewExists(int reviewId)
        {
            return _reviewContext.Reviews.Any(r => r.Id == reviewId);
        }

        public bool Save()
        {
            var saved = _reviewContext.SaveChanges();
            return saved >= 0 ? true : false;
        }

        public bool UpdateReview(Review review)
        {
            _reviewContext.Update(review);
            return Save();
        }
    }
}