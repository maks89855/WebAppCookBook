using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WebAppCookBook.API.Service;
using WebAppCookBook.Models;

namespace WebAppCookBook.API.DTOModels
{
    public class UpdateRecipeDTO
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Превышен лимит символов. Макс. кол-во 50 символов")]
        public string Name { get; set; } = "Рецепт";
        public IFormFile? Image { get; set; }
        public string? Description { get; set; }
        public ICollection<UpdateIngredientDTO>? Ingredients { get; set; } = new List<UpdateIngredientDTO>();
        public ICollection<UpdateStepDTO>? StepsCooking { get; set; } = new List<UpdateStepDTO>();
    }
}
