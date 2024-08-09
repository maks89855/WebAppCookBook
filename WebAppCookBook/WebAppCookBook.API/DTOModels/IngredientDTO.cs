using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebAppCookBook.API.Models;
using WebAppCookBook.Models;

namespace WebAppCookBook.API.DTOModels
{
	public class IngredientDTO
	{
		public int Id { get; set; }
		public int RecipeId { get; set; }
		[Required]
		public string NameIngredient { get; set; }
		[Required]
		public int Count { get; set; }
		[Required]
		public Unit Units { get; set; }
	}
}
