using ERecipePresentation.DTO;
using System.Collections.Generic;

namespace ERcipePresentation.Repositories
{
    public interface IReviewRepository
    {
        IEnumerable<ReviewDto> GetReviews();

        ReviewDto GetReview(int reviewId);

        IEnumerable<ReviewDto> GetReviewsOfARecipe(int recipeId);

        RecipeDto GetRecipeOfAReview(int reviewId);
    }
}