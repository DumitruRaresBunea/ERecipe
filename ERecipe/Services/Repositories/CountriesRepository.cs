using ERecipe.DataContext;
using ERecipe.DataContext.Models;
using System.Collections.Generic;
using System.Linq;

namespace ERecipe.Services.Repositories
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
            return _countryContext.Countries.Any(c => c.Id == countryId);
        }

        public bool CreateCountry(Country country)
        {
            _countryContext.Add(country);
            return Save();
        }

        public bool DeleteCountry(Country country)
        {
            _countryContext.Remove(country);
            return Save();
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

        public bool Save()
        {
            var saved = _countryContext.SaveChanges();
            return saved >= 0 ? true : false;
        }

        public bool UpdateCountry(Country country)
        {
            _countryContext.Update(country);
            return Save();
        }
    }
}