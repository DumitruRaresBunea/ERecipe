﻿using System;

namespace ERecipe.DTO
{
    public class RecipeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? PublishDate { get; set; }
    }
}