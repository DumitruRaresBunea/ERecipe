using System;
using System.Collections.Generic;

namespace ERecipe.Models
{
    public class Receipe
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public DateTime PublishDate { get; set; }

        public Category Category { get; set; }

        public Author Author { get; set; }

        public ICollection<Ingredient> Ingredients { get; set; }

        public ICollection<Review> Reviews { get; set; }
    }
}