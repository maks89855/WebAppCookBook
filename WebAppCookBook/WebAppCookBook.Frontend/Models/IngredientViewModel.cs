using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WebAppCookBook.API.Models;
using WebAppCookBook.API.Service;

namespace WebAppCookBook.Frontend.Models
{
    public class IngredientViewModel
	{
		public int Id { get; set; }
		public int RecipeId { get; set; }
		public string NameIngredient { get; set; }
		public int Count { get; set; }
		public Unit Units { get; set; }
	}
}
