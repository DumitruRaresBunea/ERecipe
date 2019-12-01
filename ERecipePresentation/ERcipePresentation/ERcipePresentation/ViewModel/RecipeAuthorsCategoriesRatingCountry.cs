using ERecipePresentation.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERcipePresentation.ViewModel
{
    public class RecipeAuthorsCategoriesRatingCountry
    {
        public RecipeDto Recipe { get; set; }
        public CountryDTO Country { get; set; }
        public IEnumerable<AuthorDto> Authors{ get; set; }
        public IEnumerable<CategoryDto> Categories { get; set; }
        public decimal Rating { get; set; }
    }
}
