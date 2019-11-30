using ERecipePresentation.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERcipePresentation.ViewModel
{
    public class ReviewerReviewsRecipeViewModel
    {
        public ReviewerDto Reviewer { get; set; }
        public IDictionary<ReviewDto, RecipeDto> ReviewRecipe { get; set; }
    }
}
