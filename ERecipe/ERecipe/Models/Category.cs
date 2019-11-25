using System.Collections.Generic;

namespace ERecipe.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<RecipeCategory> RecipeCategories { get; set; }


    }
}