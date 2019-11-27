using ERecipe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERecipe.Repositories
{
    public interface IReviewerRepository
    {
        ICollection<Reviewer> GetReviewers();
        Reviewer GetReviewer(int reviewId);
        ICollection<Review> GetReviewsByReviewer(int reviewerId);
        Reviewer GetReviewerOfAReview(int reviewId);
        bool ReviewerExists(int reviewerId);
    }
}
