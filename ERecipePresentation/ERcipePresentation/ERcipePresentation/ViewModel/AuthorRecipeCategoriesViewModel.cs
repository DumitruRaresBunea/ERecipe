using ERecipePresentation.DTO;
using System.Collections.Generic;

namespace ERcipePresentation.ViewModel
{
    public class AuthorRecipeCategoriesViewModel
    {
        public AuthorDto Author { get; set; }

        public IDictionary<RecipeDto, IEnumerable<CategoryDto>> RecipeCategories { get; set; }
    }
}