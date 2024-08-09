using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebAppCookBook.Models;

namespace WebAppCookBook.DTOModels
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Превышен лимит символов. Макс. кол-во 50 символов")]
        public string NameCategory { get; set; } = "Категория";
        //public ICollection<RecipeDTO> Recipes { get; set; } = new List<RecipeDTO> { };
        public CategoryDTO()
        {
            //this.NameCategory = nameCategory;
        }
    }
}
