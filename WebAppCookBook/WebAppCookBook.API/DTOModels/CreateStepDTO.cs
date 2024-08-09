using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebAppCookBook.API.Service;
using WebAppCookBook.Models;

namespace WebAppCookBook.API.DTOModels
{
    //[ModelBinder(BinderType = typeof(MetadataValueModelBinder))]
    public class CreateStepDTO
    {
        public int NumberStep { get; set; }
        public string Discription { get; set; }
    }
}
