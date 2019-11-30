using ERecipePresentation.DTO;
using System.Collections.Generic;

namespace ERcipePresentation.Repositories
{
    public interface ICountryRepository
    {
        IEnumerable<CountryDTO> GetCountries();

        CountryDTO GetCountry(int countryId);

        CountryDTO GetCountryOfARecipe(int recipeId);

        IEnumerable<RecipeDto> GetRecipesFromCountry(int countryId);
    }
}