using ERecipePresentation.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERcipePresentation.ViewModel
{
    public class CategoriesRecipesViewModel
    {
        public CategoryDto Category { get; set; }
        public IEnumerable<RecipeDto> Recipes { get; set; }
    }
}
