using ERcipePresentation.Repositories;
using ERcipePresentation.ViewModel;
using ERecipePresentation.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ERcipePresentation.Controllers
{
    public class HomeController : Controller
    {
        private IRecipeRepository _recipeRepository;
        private IAuthorRepository _authorRepository;
        private ICategoryRepository _categoryRepository;
        private ICountryRepository _countryRepository;
        private IIngredientRepository _ingredientRepository;
        private IReviewerRepository _reviewerRepository;
        private IReviewRepository _reviewRepository;
        private IStepRepository _stepRepository;

        public HomeController(IRecipeRepository recipeRepository, IAuthorRepository authorRepository, ICategoryRepository categoryRepository,
                              ICountryRepository countryRepository, IIngredientRepository ingredientRepository, IReviewerRepository reviewerRepository,
                              IReviewRepository reviewRepository, IStepRepository stepRepository)
        {
            _recipeRepository = recipeRepository;
            _authorRepository = authorRepository;
            _categoryRepository = categoryRepository;
            _countryRepository = countryRepository;
            _ingredientRepository = ingredientRepository;
            _reviewerRepository = reviewerRepository;
            _reviewRepository = reviewRepository;
            _stepRepository = stepRepository;
        }

        public IActionResult Index()
        {
            var recipes = _recipeRepository.GetRecipes();

            if (recipes.Count() <= 0)
            {
                ViewBag.Message = "There was a problem retrieving recipes from database or no recipe exists";
            }

            var recipeAuthorsCategoriesRatingCountry = new List<RecipeAuthorsCategoriesRatingCountry>();

            foreach (var recipe in recipes)
            {
                var authors = _authorRepository.GetAuthorsOfARecipe(recipe.Id).ToList();
                if (authors.Count() <= 0)
                    ModelState.AddModelError("", "Error gettin authors");

                var categories = _categoryRepository.GetAllCategoriesForRecipe(recipe.Id).ToList();
                if (categories.Count() <= 0)
                    ModelState.AddModelError("", "Error gettin categories");

                var rating = _recipeRepository.GetRecipeRatingAverage(recipe.Id);

                var country = _countryRepository.GetCountryOfARecipe(recipe.Id);

                recipeAuthorsCategoriesRatingCountry.Add(new RecipeAuthorsCategoriesRatingCountry
                {
                    Authors = authors,
                    Recipe = recipe,
                    Categories = categories,
                    Country = country,
                    Rating = rating
                });
            }

            return View(recipeAuthorsCategoriesRatingCountry);
        }

        public IActionResult GetRecipeById(int recipeId)
        {
            var completeRecipeViewModel = new CompleteRecipeViewModel();
            completeRecipeViewModel.ReviewsReviewer = new Dictionary<ReviewDto, ReviewerDto>();

           var recipe = _recipeRepository.GetRecipe(recipeId);

            if (recipe == null)
            {
                ModelState.AddModelError("", "Error retrivieng recipe");
                recipe = new RecipeDto();
            }

            var categories = _categoryRepository.GetAllCategoriesForRecipe(recipeId);
            if (categories.Count() <= 0)
            {
                ModelState.AddModelError("", "Error retrivieng categories");
            }

            var ingredients = _ingredientRepository.GetIngredientsOfARecipe(recipeId);
            if (ingredients.Count() <= 0)
            {
                ModelState.AddModelError("", "Error retrivieng ingredients");
            }

            var steps = _stepRepository.GetStepsForARecipe(recipeId);
            if (steps.Count() <= 0)
            {
                ModelState.AddModelError("", "Error retrivieng steps");
            }

            var authors = _authorRepository.GetAuthorsOfARecipe(recipeId);
            if (authors.Count() <= 0)
            {
                ModelState.AddModelError("", "Error retrivieng authors");
            }

            var reviews = _reviewRepository.GetReviewsOfARecipe(recipeId);

            foreach (var review in reviews)
            {
                var reviewer = _reviewerRepository.GetReviewerOfAReview(review.Id);
                completeRecipeViewModel.ReviewsReviewer.Add(review, reviewer);
            }

            var rating = _recipeRepository.GetRecipeRatingAverage(recipeId);

            var country = _countryRepository.GetCountryOfARecipe(recipeId);

            completeRecipeViewModel.Recipe = recipe;
            completeRecipeViewModel.Categories = categories;
            completeRecipeViewModel.Ingredients = ingredients;
            completeRecipeViewModel.Steps = steps;
            completeRecipeViewModel.Rating = rating;
            completeRecipeViewModel.Country = country;
            completeRecipeViewModel.Authors = authors;

            if (!ModelState.IsValid)
            {
                ViewBag.ViewMessage = "There was an error with getting the recipe";
            }
            return View(completeRecipeViewModel);
        }
    }
}