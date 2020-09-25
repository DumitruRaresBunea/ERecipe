namespace ERecipe.DataContext.Models
{
    public class RecipeAuthor
    {
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }

        public int AuthorID { get; set; }
        public Author Author { get; set; }
    }
}