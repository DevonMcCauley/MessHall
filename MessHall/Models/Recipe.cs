using System.ComponentModel.DataAnnotations;

namespace MessHall.Models
{
    public class Recipe
    {
        // Recipe class

        public int RecipeId { get; set; }
        [Required, MaxLength(35)]
        public string Name { get; set; }
        [Required, MaxLength(100)]
        public string Description { get; set; }
        [MaxLength(500)]
        public string Notes { get; set; }


    }
}
