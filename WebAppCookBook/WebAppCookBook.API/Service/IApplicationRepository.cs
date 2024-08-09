using WebAppCookBook.DTOModels;
using WebAppCookBook.Models;

namespace WebAppCookBook.Service
{
    public interface IApplicationRepository
    {
        Task<bool> SaveChangesAsync();

        #region Category
        Task<Category> GetCategoryAsync(int categoryId);
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<IEnumerable<Category>> GetCategoriesAsync(string searchCategory);
        Task AddCategoryAsync (Category category);
        void UpdateCategoryAsync (Category category);
        void DeleteCategoryAsync (Category category);
        Task<bool> ExistsCategoryAsync(int categoryId);
        #endregion

        #region Recipe
        Task<Recipe> GetRecipeAsync(int recipeId);
		Task<IEnumerable<Recipe>> GetRecipesAsync();
		Task<IEnumerable<Recipe>> GetRecipesAsync(string searchRecipe);
        Task AddRecipeAsync(int categoryId, Recipe recipe);
        Task<bool> ExistsRecipeAsync(int recipeId);
        void UpdateRecipeAsync(Recipe recipe);
        void DeleteRecipeAsync(Recipe recipe);
		#endregion

		#region Ingredient
		Task<Ingredient> GetIngredientAsync(int recipeId, int IngredientId);
		Task<IEnumerable<Ingredient>> GetIngredientsAsync();
		Task<IEnumerable<Ingredient>> GetIngredientsAsync(int recipeId);
		Task<IEnumerable<Ingredient>> GetIngredientsAsync(int recipeId, string searchIngredient);
		Task AddIngredientAsync(int recipeID, IEnumerable<Ingredient> Ingredient);
		Task<bool> ExistsIngredienteAsync(int ingredientId);
		void UpdateIngredientAsync(Ingredient Ingredient);
		void DeleteIngredientAsync(int recipeId, Ingredient Ingredient);
        #endregion

        #region StepCook
        Task<StepCook> GetStepAsync(int recipeId,int stepId);
        Task<IEnumerable<StepCook>> GetStepsRecipeAsync(int recipeId);
        Task AddStepAsync(int stepId, StepCook step);
        Task<bool> ExistsStepAsync(int stepId);
        void UpdateStepAsync(StepCook step);
        void DeleteStepAsync(StepCook step);

        #endregion
    }
}
