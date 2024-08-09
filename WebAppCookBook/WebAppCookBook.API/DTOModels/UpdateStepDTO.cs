using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WebAppCookBook.API.Service;

namespace WebAppCookBook.API.DTOModels
{
    public class UpdateStepDTO
    {
        [Required]
        public int NumberStep { get; set; }
        [Required]
        public string Discription { get; set; }
    }
}
