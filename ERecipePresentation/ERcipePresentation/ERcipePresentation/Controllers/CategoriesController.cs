using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERcipePresentation.Repositories;
using ERecipePresentation.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ERcipePresentation.Controllers
{
    public class CategoriesController : Controller
    {

        ICategoryRepository _categoryRepostiory;

        public CategoriesController(ICategoryRepository categoryRepostiory)
        {
            this._categoryRepostiory = categoryRepostiory;
        }

        public IActionResult Index()
        {
            var categories = _categoryRepostiory.GetCategories();

            if(categories.Count() <= 0)
            {
                ViewBag.Message = "There was a problem retrieving categories from database or no category exists";
            }
            return View(categories);
        }

        public IActionResult GetCategoryById(int categoryId)
        {
            var category = _categoryRepostiory.GetCategory(categoryId);
            if (category == null)
            {
                ModelState.AddModelError("", "Error getting a category");
                ViewBag.Message = $"There was a problem retrieving category with id {categoryId} " +
                    $"from the database or no category with that id exists";
                category = new CategoryDto();
            }
            return View(category);
        }
    }
}