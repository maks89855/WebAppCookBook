using System.ComponentModel.DataAnnotations;

namespace WebAppCookBook.Frontend.Models
{
	public class RecipeViewModel
	{
		public int Id { get; set; }
		public int CategoryId { get; set; }
		public string Image { get; set; }
		public CategoryViewModel? Category { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Превышен лимит символов. Макс. кол-во 50 символов")]
        public string Name { get; set; } = "Рецепт";
		public string? Description { get; set; }
		public ICollection<IngredientViewModel>? Ingredients { get; set; } = new List<IngredientViewModel>();
        public ICollection<StepCookViewModel>? StepsCooking { get; set; } = new List<StepCookViewModel>();
	}
}
