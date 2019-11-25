using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERecipe.Models
{
    public class RecipeAuthor
    {
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }

        public int AuthorID { get; set; }
        public Author Author { get; set; }
    }
}
