﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERecipe.Models
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Category cannot be longer than 50 characters")]
        public string Name { get; set; }

        public virtual ICollection<RecipeCategory> RecipeCategories { get; set; }


    }
}