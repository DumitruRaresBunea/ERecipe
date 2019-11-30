using ERecipePresentation.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERcipePresentation.ViewModel
{
    public class ReviewReviewerRecipeViewModel
    {
        public ReviewDto Review { get; set; }
        public ReviewerDto Reviewer { get; set; }
        public RecipeDto Recipe { get; set; }

    }
}
