using ERecipe.DataContext.Models;
using System.Collections.Generic;

namespace ERecipe.Services.Repositories
{
    public interface ICountryRepository
    {
        ICollection<Country> GetCountries();

        Country GetCountry(int countryId);

        Country GetCountryOfARecipe(int recipeId);

        ICollection<Recipe> GetRecipesFromCountry(int countryId);

        bool CountryExists(int countryId);

        bool IsDuplicateCountryName(int countryId, string countryName);

        bool CreateCountry(Country country);

        bool UpdateCountry(Country country);

        bool DeleteCountry(Country country);

        bool Save();
    }
}