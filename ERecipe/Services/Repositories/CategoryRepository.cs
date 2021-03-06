﻿using ERecipe.DataContext;
using ERecipe.DataContext.Models;
using System.Collections.Generic;
using System.Linq;

namespace ERecipe.Services.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private RecipeDbContext _categoryContext;

        public CategoryRepository(RecipeDbContext categotyContext)
        {
            _categoryContext = categotyContext;
        }

        public bool CategoryExists(int categoryId)
        {
            return _categoryContext.Categories.Any(c => c.Id == categoryId);
        }

        public ICollection<Category> GetCategories()
        {
            return _categoryContext.Categories.OrderBy(c => c.Name).ToList();
        }

        public ICollection<Category> GetAllCategoriesForRecipe(int recipeId)
        {
            return _categoryContext.RecipeCategories.Where(r => r.RecipeId == recipeId).Select(c => c.Category).ToList();
        }

        public Category GetCategory(int categoryId)
        {
            return _categoryContext.Categories.Where(c => c.Id == categoryId).FirstOrDefault();
        }

        public ICollection<Recipe> GetRecipesOfCategory(int categoryId)
        {
            return _categoryContext.RecipeCategories.Where(c => c.CategoryId == categoryId).Select(r => r.Recipe).ToList();
        }

        public bool IsDupliocateCategoryName(int categoryId, string categoryName)
        {
            var category = _categoryContext.Categories.Where(c => c.Name.Trim().ToUpper() == categoryName.Trim().ToUpper()
            && c.Id != categoryId).FirstOrDefault();

            return category == null ? false : true;
        }

        public bool CreateCategory(Category category)
        {
            _categoryContext.Add(category);
            return Save();
        }

        public bool UpdateCategory(Category category)
        {
            _categoryContext.Update(category);
            return Save();
        }

        public bool DeleteCategory(Category category)
        {
            _categoryContext.Remove(category);
            return Save();
        }

        public bool Save()
        {
            var saved = _categoryContext.SaveChanges();
            return saved >= 0 ? true : false;
        }
    }
}