using AutoMapper;
using WebAppCookBook.API.DTOModels;
using WebAppCookBook.DTOModels;
using WebAppCookBook.Models;

namespace WebAppCookBook.Profiles
{
    public class RecipeProfile : Profile
    {
        public RecipeProfile()
        {
            CreateMap<CreateRecipeDTO, Recipe>();
            CreateMap<Recipe, RecipeDTO>();
            CreateMap<RecipeDTO, Recipe>();
            CreateMap<UpdateRecipeDTO, Recipe>();
            CreateMap<Recipe, UpdateRecipeDTO>();
        }
    }
}
