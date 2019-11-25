using System;
using System.Collections.Generic;

namespace ERecipe.Models
{
    public class Recipe
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public DateTime PublishDate { get; set; }

        public virtual Author Author { get; set; }

        public virtual ICollection<RecipeCategory> RecipeCategories { get; set; }

        public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; }

        public virtual ICollection<RecipeAuthor> RecipeAuthors { get; set; }
    }
}