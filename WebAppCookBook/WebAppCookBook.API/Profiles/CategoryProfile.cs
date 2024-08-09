using AutoMapper;
using WebAppCookBook.API.DTOModels;
using WebAppCookBook.DTOModels;
using WebAppCookBook.Models;

namespace WebAppCookBook.Profiles
{
    public class CategoryProfile: Profile
    {
        public CategoryProfile()
        {
            CreateMap<CreateCategoryDTO, Category>();
            CreateMap<Category, CategoryDTO>();
            CreateMap<UpdateCategoryDTO, Category>();
            CreateMap<Category, UpdateCategoryDTO>();
        }
    }
}
