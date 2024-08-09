using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebAppCookBook.API.Models;
using WebAppCookBook.API.Service;
using WebAppCookBook.Models;

namespace WebAppCookBook.API.DTOModels
{
    public class UpdateIngredientDTO
	{
		[Required]
		public string NameIngredient { get; set; }
		[Required]
		public int Count { get; set; }
		[Required]
		public Unit Units { get; set; }
	}
}
