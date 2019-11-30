using ERcipePresentation.Repositories;
using ERecipePresentation.DTO;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace ERecipe.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        public RecipeDto GetRecipe(int recipeId)
        {
            RecipeDto recipe = new RecipeDto();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49951/api/");

                var response = client.GetAsync($"recipes/{recipeId}");
                response.Wait();

                var result = response.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<RecipeDto>();
                    readTask.Wait();

                    recipe = readTask.Result;
                }
            }

            return recipe;
        }

        public decimal GetRecipeRatingAverage(int recipeId)
        {
            decimal rating = 0.0m;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49951/api/");

                var response = client.GetAsync($"recipes/{recipeId}/rating");
                response.Wait();

                var result = response.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<decimal>();
                    readTask.Wait();

                    rating = readTask.Result;
                }
            }

            return rating;
        }

        public IEnumerable<RecipeDto> GetRecipes()
        {
            IEnumerable<RecipeDto> recipes = new List<RecipeDto>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49951/api/");

                var response = client.GetAsync("recipes");
                response.Wait();

                var result = response.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<RecipeDto>>();
                    readTask.Wait();

                    recipes = readTask.Result;
                }
            }

            return recipes;
        }
    }
}