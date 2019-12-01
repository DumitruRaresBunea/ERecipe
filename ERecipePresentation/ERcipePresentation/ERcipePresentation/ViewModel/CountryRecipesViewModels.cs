using ERecipePresentation.DTO;
using System.Collections.Generic;

namespace ERcipePresentation.ViewModel
{
    public class CountryRecipesViewModels
    {
        public CountryDTO Country { get; set; }
        public IEnumerable<RecipeDto> Recipes { get; set; }
    }
}