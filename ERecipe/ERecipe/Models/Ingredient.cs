using System.Collections.Generic;

namespace ERecipe.Models
{
    public class Ingredient
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Quantity { get; set; }

        public ICollection<Receipe> Receipes { get; set; }

    }
}