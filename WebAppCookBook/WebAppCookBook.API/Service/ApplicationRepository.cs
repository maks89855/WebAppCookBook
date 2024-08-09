using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppCookBook.API.Service;
using WebAppCookBook.DbContexts;
using WebAppCookBook.DTOModels;
using WebAppCookBook.Models;

namespace WebAppCookBook.Service
{
    public class ApplicationRepository: IApplicationRepository

    {
        private readonly ApplicationContext _context;

		public ApplicationRepository(ApplicationContext context) 
        {
            this._context = context;
        }

        public async Task AddCategoryAsync(Category category)
        {
            _context.Categories.Add(category);
        }
        //TODO: Переделать под список ингредиентов
        public async Task AddIngredientAsync(int recipeID, IEnumerable<Ingredient> Ingredients)
		{
			var recipe = await _context.Recipes.FirstOrDefaultAsync(c=>c.Id == recipeID);
            if (recipe != null)
            {
                foreach(var ingredient in Ingredients)
                {
                    recipe.Ingredients.Add(ingredient);
                }
            }
		}

		public async Task AddRecipeAsync(int categoryId, Recipe recipe)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == categoryId);      
            if(category != null)
            {
				category.Recipes.Add(recipe);
			}           
        }

        public async Task AddStepAsync(int recipeId, StepCook step)
        {
            var recipe = await _context.Recipes.FirstOrDefaultAsync(c=>c.Id==recipeId);
            if(recipe != null)
            {
                recipe.StepsCooking.Add(step);
            }
        }

        public void DeleteCategoryAsync(Category category)
        {
            _context.Categories.Remove(category);
        }


		public async void DeleteIngredientAsync(int recipeId, Ingredient Ingredient)
		{
            var recipe = await _context.Recipes.FirstOrDefaultAsync(_ => _.Id == recipeId);
            if(recipe != null)
            {
                recipe.Ingredients.Remove(Ingredient);
            }
		}

        public void DeleteRecipeAsync(Recipe recipe)

        {
            _context.Recipes.Remove(recipe);
        }


        public void DeleteStepAsync(StepCook step)
        {
            throw new NotImplementedException();
        }


        public async Task<bool> ExistsCategoryAsync(int categoryId)
        {
            return await _context.Categories.AnyAsync(c=>c.Id == categoryId);
        }


		public async Task<bool> ExistsIngredienteAsync(int IngredientId)
		{
			return await _context.Ingredients.AnyAsync(c => c.Id == IngredientId);
		}

		public async Task<bool> ExistsRecipeAsync(int recipeId)
        {
            return await _context.Recipes.AnyAsync(c=> c.Id == recipeId);
        }

        public async Task<bool> ExistsRecipeAsync(int categoryId,int recipeId)
        {
            return await _context.Recipes.AnyAsync(c=> c.CategoryId == categoryId && c.Id == recipeId);
        }
        public async Task<bool> ExistsStepAsync(int stepId)
        {
            return await _context.StepCooks.AnyAsync(c=>c.Id==stepId);
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync(string searchCategory)
        {
            if (string.IsNullOrWhiteSpace(searchCategory))
            {
                return await GetCategoriesAsync();
            }
            searchCategory = searchCategory.Trim();
            return await _context.Categories.Where(c => c.NameCategory == searchCategory).ToListAsync();
        }
        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryAsync(int categoryId)
        {
            return await _context.Categories.Where(c=>c.Id == categoryId).FirstOrDefaultAsync();
        }

		public async Task<Ingredient> GetIngredientAsync(int recipeId, int IngredientId)
		{
            return await _context.Ingredients.Where(c =>c.RecipeId == recipeId && c.Id == IngredientId).FirstOrDefaultAsync();
		}

		public async Task<IEnumerable<Ingredient>> GetIngredientsAsync()
		{
            return await _context.Ingredients.ToListAsync();
		}

		public async Task<IEnumerable<Ingredient>> GetIngredientsAsync(int recipeId)
		{
            return await _context.Ingredients.Where(c => c.RecipeId == recipeId).OrderBy(item=>item.NameIngredient).ToListAsync();
		}

		public Task<IEnumerable<Ingredient>> GetIngredientsAsync(int recipeId, string searchIngredient)
		{
			throw new NotImplementedException();
		}

        public async Task<Recipe> GetRecipeAsync(int recipeId)
        {
            return await _context.Recipes.Where(f =>f.Id == recipeId).FirstOrDefaultAsync();
        }
		public async Task<IEnumerable<Recipe>> GetRecipesAsync()
		{
            return await _context.Recipes.ToListAsync();
		}
        public async Task<IEnumerable<Recipe>> GetRecipesAsync(string seacrhRecipe)
        {
            if (string.IsNullOrWhiteSpace(seacrhRecipe)) return await GetRecipesAsync();
            seacrhRecipe = seacrhRecipe.Trim();
            return 
                await _context.Recipes.
                Where(c => c.Name.Contains(seacrhRecipe)).
                ToListAsync();
        }

        public async Task<StepCook> GetStepAsync(int recipeId, int stepId)
        {
            return await _context.StepCooks.
                Where(f=>f.RecipeId == recipeId && f.Id == stepId).
                FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<StepCook>> GetStepsRecipeAsync(int recipeId)
        {
            return 
                await _context.StepCooks.
                Where(f=>f.RecipeId==recipeId).
                OrderBy(item=>item.NumberStep).
                ToListAsync();
        }
        public async Task<IEnumerable<Recipe>> GetRecipesAsync(int categoryId,string seacrhRecipe)
        {
            if (string.IsNullOrWhiteSpace(seacrhRecipe)) return await GetRecipesAsync();
            seacrhRecipe = seacrhRecipe.Trim();
            return 
                await _context.Recipes.
                Where(c => c.CategoryId == categoryId && c.Name.Contains(seacrhRecipe)).
                ToListAsync();
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (_context.SaveChanges()>=0);
        }

        public void UpdateCategoryAsync(Category category)
        {
            throw new NotImplementedException();
        }

		public void UpdateIngredientAsync(Ingredient Ingredient)
		{
            throw new NotImplementedException();
        }

		public void UpdateRecipeAsync(Recipe recipe)
        {
            throw new NotImplementedException();
        }

        public void UpdateStepAsync(StepCook step)
        {
            throw new NotImplementedException();
        }

    }
}
