﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERecipe.Models
{
    public class Recipe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime PublishDate { get; set; } = DateTime.Now;

        public virtual Author Author { get; set; }

        public virtual ICollection<RecipeCategory> RecipeCategories { get; set; }

        public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; }

        public virtual ICollection<RecipeAuthor> RecipeAuthors { get; set; }
    }
}