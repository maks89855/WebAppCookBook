using System.ComponentModel.DataAnnotations;
using WebAppCookBook.API.DTOModels;
using WebAppCookBook.Models;

namespace WebAppCookBook.Frontend.Models
{
    public class CreateRecipeModel
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Превышен лимит символов. Макс. кол-во 50 символов")]
        public string Name { get; set; }
        public IFormFile? Image { get; set; }
        public string? Description { get; set; }
        public List<IngredientViewModel>? Ingredients { get; set; } = new List<IngredientViewModel>();
        public List<CreateStepDTO>? StepsCooking { get; set; } = new List<CreateStepDTO>();
    }
}
