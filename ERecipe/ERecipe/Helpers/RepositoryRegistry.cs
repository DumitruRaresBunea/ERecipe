using ERecipe.Services.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ERecipe.Helpers
{
    public static class RepositoryRegistry
    {
        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            return
                services
                    .AddTransient<ICountryRepository, CountriesRepository>()
                    .AddTransient<ICategoryRepository, CategoryRepository>()
                    .AddTransient<IAuthorRepository, AuthorRepository>()
                    .AddTransient<IIngredientRepository, IngredientRepository>()
                    .AddTransient<IReviewerRepository, ReviewerRepository>()
                    .AddTransient<IReviewRepository, ReviewRepository>()
                    .AddTransient<IStepRepository, StepRepository>()
                    .AddTransient<IRecipeRepository, RecipeRepository>();
        }
    }
}