using System;
using System.Collections.Generic;
using System.Net.Http;
using ERcipePresentation.Repositories;
using ERecipePresentation.DTO;

namespace ERecipe.Repositories
{
    public class StepRepository : IStepRepository
    {
        public RecipeDto GetRecipeOfAStep(int stepId)
        {
            RecipeDto recipe = new RecipeDto();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49951/api/");

                var response = client.GetAsync($"steps/{stepId}/recipe");
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

        public StepDto GetStep(int stepId)
        {
            StepDto step = new StepDto();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49951/api/");

                var response = client.GetAsync($"step/{stepId}");
                response.Wait();

                var result = response.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<StepDto>();
                    readTask.Wait();

                    step = readTask.Result;
                }
            }

            return step;
        }

            public IEnumerable<StepDto> GetSteps()
        {
            IEnumerable<StepDto> steps = new List<StepDto>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49951/api/");

                var response = client.GetAsync("steps");
                response.Wait();

                var result = response.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<StepDto>>();
                    readTask.Wait();

                    steps = readTask.Result;
                }
            }

            return steps;
        }

        public IEnumerable<StepDto> GetStepsForARecipe(int recipeId)
        {
            IEnumerable<StepDto> step = new List<StepDto>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49951/api/");

                var response = client.GetAsync($"categories/recipes/{recipeId}");
                response.Wait();

                var result = response.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<StepDto>>();
                    readTask.Wait();

                    step = readTask.Result;
                }
            }

            return step;
        }
    }
}