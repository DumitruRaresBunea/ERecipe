using ERecipe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERecipe.Repositories
{
    public interface ICountryRepository
    {
        ICollection<Country> GetCountries();

        Country GetCountry(int countryId);

        Country GetCountryOfARecipe(int recipeId);

        ICollection<Recipe> GetRecipesFromCountry(int countryId);

        bool CheckIfExists(int countryId);
    }
}
