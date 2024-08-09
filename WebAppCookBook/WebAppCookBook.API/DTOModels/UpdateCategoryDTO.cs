using System.ComponentModel.DataAnnotations;

namespace WebAppCookBook.API.DTOModels
{
    public class UpdateCategoryDTO
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Превышен лимит символов. Макс. кол-во 50 символов")]
        public string NameCategory { get; set; } = "Категория";
    }
}
