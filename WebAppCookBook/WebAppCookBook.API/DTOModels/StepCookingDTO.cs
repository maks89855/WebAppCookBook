using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebAppCookBook.Models;

namespace WebAppCookBook.API.DTOModels
{
    public class StepCookingDTO
    {
        public int Id { get; set; }
        [Required]
        public int NumberStep { get; set; }
        public int RecipeId { get; set; }
        [Required]
        public string Discription { get; set; }
    }
}
