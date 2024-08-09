using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WebAppCookBook.API.Models;
using WebAppCookBook.API.Service;
using WebAppCookBook.DTOModels;
using WebAppCookBook.Models;

namespace WebAppCookBook.API.DTOModels
{
    //[ModelBinder(BinderType = typeof(MetadataValueModelBinder))]
    [ModelBinder(BinderType = typeof(TypeBinder))]
    public class CreateIngredientDTO
	{
		[Required]
		public string NameIngredient { get; set; } = "Название";
		[Required]
		public int Count { get; set; } = 1;
		[Required]
		public Unit Units { get; set; } = Unit.кг;
	}
}
