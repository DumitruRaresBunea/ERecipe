using ERecipePresentation.DTO;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace ERcipePresentation.Repositories
{
    public class IngredientRepository : IIngredientRepository
    {
        public IngredientDto GetIngredient(int ingredientId)
        {
            IngredientDto ingredient = new IngredientDto();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49951/api/");

                var response = client.GetAsync($"ingredients/{ingredientId}");
                response.Wait();

                var result = response.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IngredientDto>();
                    readTask.Wait();

                    ingredient = readTask.Result;
                }
            }

            return ingredient;
        }

        public IEnumerable<IngredientDto> GetIngredients()
        {
            IEnumerable<IngredientDto> ingredients = new List<IngredientDto>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49951/api/");

                var response = client.GetAsync("ingredients");
                response.Wait();

                var result = response.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<IngredientDto>>();
                    readTask.Wait();

                    ingredients = readTask.Result;
                }
            }

            return ingredients;
        }

        public IEnumerable<IngredientDto> GetIngredientsOfARecipe(int recipeId)
        {
            IEnumerable<IngredientDto> ingredients = new List<IngredientDto>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49951/api/");

                var response = client.GetAsync($"ingredients/recipes/{recipeId}");
                response.Wait();

                var result = response.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<IngredientDto>>();
                    readTask.Wait();

                    ingredients = readTask.Result;
                }
            }

            return ingredients;
        }

        public RecipeDto GetRecipeOfAIngredient(int ingredientId)
        {
            RecipeDto recipe = new RecipeDto();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49951/api/");

                var response = client.GetAsync($"ingredients/{ingredientId}/recipe");
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
    }
}