using ERecipe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERecipe.Repositories
{
    public interface ICategoryRepository
    {
        ICollection<Category> GetCategories();

        Category GetCategory(int categoryId);

        ICollection<Category> GetAllCategoriesForRecipe(int recipeId);

        ICollection<Recipe> GetRecipesOfCategory(int categoryId);

        bool CountryExists(int categoryId);
    }
}
}
