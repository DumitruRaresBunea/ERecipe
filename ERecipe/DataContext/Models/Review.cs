using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERecipe.DataContext.Models
{
    public class Review
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string ReviewText { get; set; }

        public string Headline { get; set; }

        public int Rating { get; set; }

        public virtual Reviewer Reviewer { get; set; }
        public virtual Recipe ReviewdRecipe { get; set; }
    }
}