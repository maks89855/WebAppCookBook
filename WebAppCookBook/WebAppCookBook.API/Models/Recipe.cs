using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Net.Mime.MediaTypeNames;

namespace WebAppCookBook.Models
{
    public class Recipe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [DefaultValue("main_default.jpg")]
        public string? Image { get; set; } = "main_default.jpg";
        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }
        public int CategoryId { get; set; } = 1;
        [Required]
        [MaxLength(50, ErrorMessage = "Превышен лимит символов. Макс. кол-во 50 символов")]
        public string Name { get; set; }
        public string? Description { get; set; }
		[FromForm(Name = "Ingredients")]
		public ICollection<Ingredient>? Ingredients { get; set; } = new List<Ingredient>();
        public ICollection<StepCook>? StepsCooking { get; set; } = new List<StepCook>();

        public Recipe()
        {
            this.Image = "main_default.jpg";
            this.Name = "Рецепт";

		}
    }
}
