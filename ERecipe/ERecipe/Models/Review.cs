using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERecipe.Models
{
    public class Review
    {
        public int Id { get; set; }

        public string ReviewText { get; set; }

        public string Headline { get; set; }

        public int Rating { get; set; }

        public virtual Reviewer Reviewer { get; set; }
        public virtual Recipe ReviewdRecipe { get; set; }
    }
}
