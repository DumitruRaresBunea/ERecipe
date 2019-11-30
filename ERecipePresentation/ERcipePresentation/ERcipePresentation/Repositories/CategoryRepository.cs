using ERecipePresentation.DTO;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace ERcipePresentation.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        public IEnumerable<CategoryDto> GetAllCategoriesForRecipe(int recipeId)
        {
            IEnumerable<CategoryDto> categories = new List<CategoryDto>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49951/api/");

                var response = client.GetAsync($"categories/recipes/{recipeId}");
                response.Wait();

                var result = response.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<CategoryDto>>();
                    readTask.Wait();

                    categories = readTask.Result;
                }
            }

            return categories;
        }

        public IEnumerable<CategoryDto> GetCategories()
        {
            IEnumerable<CategoryDto> categories = new List<CategoryDto>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49951/api/");

                var response = client.GetAsync("categories");
                response.Wait();

                var result = response.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<CategoryDto>>();
                    readTask.Wait();

                    categories = readTask.Result;
                }
            }

            return categories;
        }

        public CategoryDto GetCategory(int categoryId)
        {
            CategoryDto category = new CategoryDto();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49951/api/");

                var response = client.GetAsync($"categories/{categoryId}");
                response.Wait();

                var result = response.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<CategoryDto>();
                    readTask.Wait();

                    category = readTask.Result;
                }
            }

            return category;
        }

        public IEnumerable<RecipeDto> GetRecipesOfCategory(int categoryId)
        {
            IEnumerable<RecipeDto> recipes = new List<RecipeDto>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49951/api/");
                var response = client.GetAsync($"categories/{categoryId}/recipes");
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