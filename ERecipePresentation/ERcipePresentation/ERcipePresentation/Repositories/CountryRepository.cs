using ERecipePresentation.DTO;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace ERcipePresentation.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        public IEnumerable<CountryDTO> GetCountries()
        {
            IEnumerable<CountryDTO> countries = new List<CountryDTO>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49951/api/");

                var response = client.GetAsync("countries");
                response.Wait();

                var result = response.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<CountryDTO>>();
                    readTask.Wait();

                    countries = readTask.Result;
                }
                return countries;
            }
        }

        public CountryDTO GetCountry(int countryId)
        {
            CountryDTO country = new CountryDTO();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49951/api/");

                var response = client.GetAsync($"countries/{countryId}");
                response.Wait();

                var result = response.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<CountryDTO>();
                    readTask.Wait();

                    country = readTask.Result;
                }
            }

            return country;
        }

        public CountryDTO GetCountryOfARecipe(int recipeId)
        {
            CountryDTO country = new CountryDTO();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49951/api/");

                var response = client.GetAsync($"countries/recipes/{recipeId}");
                response.Wait();

                var result = response.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<CountryDTO>();
                    readTask.Wait();

                    country = readTask.Result;
                }
            }

            return country;
        }

        public IEnumerable<RecipeDto> GetRecipesFromCountry(int countryId)
        {
            IEnumerable<RecipeDto> authors = new List<RecipeDto>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49951/api/");

                var response = client.GetAsync($"countries/{countryId}/recipes");
                response.Wait();

                var result = response.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<RecipeDto>>();
                    readTask.Wait();

                    authors = readTask.Result;
                }
            }

            return authors;
        }
    }
}