using ERecipePresentation.DTO;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace ERcipePresentation.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        public RecipeDto GetRecipeOfAReview(int reviewId)
        {
            RecipeDto recipe = new RecipeDto();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49951/api/");

                var response = client.GetAsync($"reviews/{reviewId}/recipe");
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

        public ReviewDto GetReview(int reviewId)
        {
            ReviewDto review = new ReviewDto();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49951/api/");

                var response = client.GetAsync($"reviews/{reviewId}");
                response.Wait();

                var result = response.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ReviewDto>();
                    readTask.Wait();

                    review = readTask.Result;
                }
            }

            return review;
        }

        public IEnumerable<ReviewDto> GetReviews()
        {
            IEnumerable<ReviewDto> reviews = new List<ReviewDto>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49951/api/");

                var response = client.GetAsync("reviews");
                response.Wait();

                var result = response.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<ReviewDto>>();
                    readTask.Wait();

                    reviews = readTask.Result;
                }
            }

            return reviews;
        }

        public IEnumerable<ReviewDto> GetReviewsOfARecipe(int recipeId)
        {
            IEnumerable<ReviewDto> reviews = new List<ReviewDto>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49951/api/");

                var response = client.GetAsync($"reviews/recipes/{recipeId}");
                response.Wait();

                var result = response.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<ReviewDto>>();
                    readTask.Wait();

                    reviews = readTask.Result;
                }
            }

            return reviews;
        }
    }
}