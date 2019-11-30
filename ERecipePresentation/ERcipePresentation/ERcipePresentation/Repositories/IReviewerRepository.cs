using ERecipePresentation.DTO;
using System.Collections.Generic;

namespace ERcipePresentation.Repositories
{
    public interface IReviewerRepository
    {
        IEnumerable<ReviewerDto> GetReviewers();

        ReviewerDto GetReviewer(int reviewerId);

        IEnumerable<ReviewDto> GetReviewsByReviewer(int reviewerId);

        ReviewerDto GetReviewerOfAReview(int reviewId);
    }
}