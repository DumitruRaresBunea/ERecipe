using System;
using System.Collections.Generic;
using System.Net.Http;
using ERcipePresentation.Repositories;
using ERecipePresentation.DTO;

namespace ERecipe.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        public AuthorDto GetAuthor(int authorId)
        {
            AuthorDto author = new AuthorDto();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49951/api/");

                var response = client.GetAsync($"authors/{authorId}");
                response.Wait();

                var result = response.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<AuthorDto>();
                    readTask.Wait();

                    author = readTask.Result;
                }
            }

            return author;
        }

        public IEnumerable<AuthorDto> GetAuthors()
        {
            IEnumerable<AuthorDto> authors = new List<AuthorDto>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49951/api/");

                var response = client.GetAsync("authors");
                response.Wait();

                var result = response.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<AuthorDto>>();
                    readTask.Wait();

                    authors = readTask.Result;
                }
            }

            return authors;
        }

        public IEnumerable<AuthorDto> GetAuthorsOfARecipe(int recipeId)
        {
            IEnumerable<AuthorDto> author = new List<AuthorDto>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49951/api/");

                var response = client.GetAsync($"authors/recipes/{recipeId}");
                response.Wait();

                var result = response.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<AuthorDto>>();
                    readTask.Wait();

                    author = readTask.Result;
                }
            }

            return author;
        }

        public IEnumerable<RecipeDto> GetRecipesOfAAuthor(int authorId)
        {
            IEnumerable<RecipeDto> books = new List<RecipeDto>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49951/api/");

                var response = client.GetAsync($"authors/{authorId}/recipes");
                response.Wait();

                var result = response.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<RecipeDto>>();
                    readTask.Wait();

                    books = readTask.Result;
                }
            }

            return books;
        }
    }
}