using AutoMapper;
using WebAppCookBook.API.DTOModels;
using WebAppCookBook.Models;

namespace WebAppCookBook.API.Profiles
{
	public class IngredientProfile : Profile
	{
        public IngredientProfile()
        {
            CreateMap<IngredientDTO, Ingredient>();
            CreateMap<Ingredient, IngredientDTO>();
            CreateMap<CreateIngredientDTO, Ingredient>();
            CreateMap<UpdateIngredientDTO, Ingredient>();
            CreateMap<Ingredient, UpdateIngredientDTO>();
        }
    }
}
