using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERecipe.Models;
using ERecipe.Services;

namespace ERecipe.Repositories
{
    public class CountriesRepository : ICountryRepository
    {
        private RecipeDbContext _countryContext;

        public CountriesRepository(RecipeDbContext countryContext)
        {
            _countryContext = countryContext;
        }

        public bool CountryExists(int countryId)
        {
            return _countryContext.Countries.Any(c =>c.Id==countryId);
        }

        //Gets all countries
        public ICollection<Country> GetCountries()
        {
            return _countryContext.Countries.OrderBy(c => c.Name).ToList();
        }
        //Gets a country
        public Country GetCountry(int countryId)
        {
            return _countryContext.Countries.Where(c => c.Id == countryId).FirstOrDefault();

        }
        //Gets country from a receipt
        public Country GetCountryOfARecipe(int recipeId)
        {
            return _countryContext.Recipes.Where(r => r.Id == recipeId).Select(c => c.Country).FirstOrDefault();
        }
        //Gets all recieps of a country
        public ICollection<Recipe> GetRecipesFromCountry(int countryId)
        {
            return _countryContext.Recipes.Where(c => c.Id == countryId).ToList();
        }

        public bool IsDuplicateCountryName(int countryId, string countryName)
        {
            var country = _countryContext.Countries.Where(c => c.Name.Trim().ToUpper() == countryName.Trim().ToUpper() 
            && c.Id != countryId).FirstOrDefault();

            return country == null ? false : true;
        }
    }
}
