using System.ComponentModel.DataAnnotations;
using WebAppCookBook.DTOModels;

namespace WebAppCookBook.API.ValidationAttributes
{
    public class CategoryDoesntContainAttribute : ValidationAttribute
    {
        private List<string> _badCategoriesNames = new List<string>
        {
            "test"
        };
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var category = (CreateCategoryDTO)validationContext.ObjectInstance;
            foreach(var item in _badCategoriesNames)
            {
                if (item.Contains(category.NameCategory))
                {
                     return new ValidationResult(ErrorMessage);
                }
            }
        return ValidationResult.Success;
        }
    }
}
