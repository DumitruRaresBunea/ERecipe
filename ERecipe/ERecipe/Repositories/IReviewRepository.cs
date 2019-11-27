using ERecipe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERecipe.Repositories
{
    public interface IReviewRepository
    {
        ICollection<Review> GetReviews();
        Review GetReview(int reviewId);
        ICollection<Review> GetReviewsOfARecipe(int recipeId);
        Recipe GetRecipeOfAReview(int reviewId);
        bool ReviewExists(int reviewId);
    }
}
