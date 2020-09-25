using ERecipe.DataContext.Models;
using System.Collections.Generic;

namespace ERecipe.Services.Repositories
{
    public interface IReviewRepository
    {
        ICollection<Review> GetReviews();

        Review GetReview(int reviewId);

        ICollection<Review> GetReviewsOfARecipe(int recipeId);

        Recipe GetRecipeOfAReview(int reviewId);

        bool ReviewExists(int reviewId);

        bool CreateReview(Review review);

        bool UpdateReview(Review review);

        bool DeleteReview(Review review);

        public bool DeleteReviews(List<Review> reviews);

        bool Save();
    }
}