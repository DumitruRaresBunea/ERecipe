using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERecipe.DTO
{
    public class ReviewDto
    {
        public int Id { get; set; }
        public string ReviewTest { get; set; }
        public string Headline { get; set; }
        public int Rating { get; set; }
    }
}
