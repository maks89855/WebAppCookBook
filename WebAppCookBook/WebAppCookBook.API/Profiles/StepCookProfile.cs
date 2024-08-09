using AutoMapper;
using WebAppCookBook.API.DTOModels;
using WebAppCookBook.DTOModels;
using WebAppCookBook.Models;

namespace WebAppCookBook.API.Profiles
{
    public class StepCookProfile: Profile
    {
        public StepCookProfile()
        {
            CreateMap<CreateStepDTO, StepCook>();
            CreateMap<StepCook, StepCookingDTO>();
            CreateMap<StepCookingDTO, StepCook>();
            CreateMap<UpdateStepDTO, StepCook>();
            CreateMap<StepCook, UpdateStepDTO>();
        }
    }
}
