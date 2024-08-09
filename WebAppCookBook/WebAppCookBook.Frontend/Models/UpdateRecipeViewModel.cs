using System.ComponentModel.DataAnnotations;
using WebAppCookBook.Models;

namespace WebAppCookBook.Frontend.Models
{
    public class UpdateRecipeViewModel
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Превышен лимит символов. Макс. кол-во 50 символов")]
        public string Name { get; set; } = "Рецепт";
        public IFormFile? Image { get; set; }
        public string? Description { get; set; }
        public ICollection<Ingredient>? Ingredients { get; set; } = new List<Ingredient>();
        public ICollection<StepCook>? StepsCooking { get; set; } = new List<StepCook>();
    }
}
