using System.ComponentModel.DataAnnotations;

namespace MessHall.Models
{
    public class Ingredient
    {
        // Ingredient class

        public int IngredientId { get; set; }

        [Required, MaxLength(35)]
        public string Name { get; set; }

        [Required, MaxLength(100)]
        public string Description { get; set; }

        [Required]
        public double CaloriesPerUnit { get; set; }

        public Recipe Recipe { get; set; }
        public int RecipeId { get; set; }
    }
}