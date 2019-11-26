using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERecipe.Models
{
    public class Ingredient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Ingredient name cannot be longer than 100 characters")]
        public string Name { get; set; }

        public double Quantity { get; set; }

        public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; }


    }
}