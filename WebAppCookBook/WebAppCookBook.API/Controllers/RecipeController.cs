using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using WebAppCookBook.API.DTOModels;
using WebAppCookBook.API.Service;
using WebAppCookBook.DTOModels;
using WebAppCookBook.Models;
using WebAppCookBook.Service;

namespace WebAppCookBook.Controllers
{
    [Route("api/recipes")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly IImageRepository _imageRepository;
        private readonly IMapper _mapper;

        public RecipeController(IApplicationRepository applicationRepository,IImageRepository imageRepository, IMapper mapper)
        {
            this._applicationRepository = applicationRepository;
            this._mapper = mapper;
            this._imageRepository = imageRepository;
        }
        [HttpGet("{recipeId}", Name = "GetRecipe")]
        //TODO: Добавить bool выражения для отображения ингредиентов, шагов
        public async Task<ActionResult<RecipeDTO>> GetRecipe(int recipeId)
        {
            var recipe = await _applicationRepository.GetRecipeAsync(recipeId);
            if (recipe == null)
            {
                return NotFound();
            }
            var recipefinnaly = _mapper.Map<RecipeDTO>(recipe);
            var category = await _applicationRepository.GetCategoryAsync(recipe.CategoryId);
            var ingredients = await _applicationRepository.GetIngredientsAsync(recipeId);
            var stepsCooking = await _applicationRepository.GetStepsRecipeAsync(recipeId);
            recipefinnaly.Category = _mapper.Map<CategoryDTO>(category);
            recipefinnaly.Ingredients = _mapper.Map<IEnumerable<IngredientDTO>>(ingredients).ToList();
            recipefinnaly.StepsCooking = _mapper.Map<IEnumerable<StepCookingDTO>>(stepsCooking).ToList();
            return Ok(recipefinnaly);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecipeDTO>>> GetRecipesAsync(string? searchRecipe)
        {
            var recipes = await _applicationRepository.GetRecipesAsync(searchRecipe);
            if (recipes == null)
            {
                return NotFound();
            }
            foreach (var recipe in recipes)
            {
                var ingredients = await _applicationRepository.GetIngredientsAsync(recipe.Id);
                var stepsCooking = await _applicationRepository.GetStepsRecipeAsync(recipe.Id);
                recipe.Category = await _applicationRepository.GetCategoryAsync(recipe.CategoryId);
                recipe.Ingredients = _mapper.Map<IEnumerable<Ingredient>>(ingredients).ToList();
                recipe.StepsCooking = _mapper.Map<IEnumerable<StepCook>>(stepsCooking).ToList();
            }
            return Ok(_mapper.Map<IEnumerable<RecipeDTO>>(recipes));
        }


        [HttpPost("{categoryId}")]
		public async Task<ActionResult<RecipeDTO>> AddRecipeAsync(int categoryId, [FromForm]CreateRecipeDTO createRecipeDTO)
        {
            if(!await _applicationRepository.ExistsCategoryAsync(categoryId)) return NotFound();
            var recipe = _mapper.Map<Recipe>(createRecipeDTO);
            await _applicationRepository.AddRecipeAsync(categoryId, recipe);
			await _applicationRepository.SaveChangesAsync();
            if(createRecipeDTO.Image != null)
            {
                recipe.Image = await _imageRepository.Upload(createRecipeDTO.Image, $"{recipe.Id}");
                await _applicationRepository.SaveChangesAsync();
            }			
			var recipeFinnaly = _mapper.Map<RecipeDTO>(recipe);
            return CreatedAtRoute("GetRecipe", new
            {              
                recipeId = recipeFinnaly.Id

            }, recipeFinnaly);
        }


		[HttpOptions]
        public IActionResult GetRecipeOptions()
        {
            Response.Headers.Add("Allow", "GET, POST");
            return Ok();
        }

        [HttpPut("{recipeId}")]
        public async Task<ActionResult<Recipe>> UpdateRecipe(int recipeId, [FromForm]UpdateRecipeDTO updateRecipeDTO)
        {
            if(!await _applicationRepository.ExistsRecipeAsync(recipeId))
            {
                return NotFound();
            }         
            var recipe = await _applicationRepository.GetRecipeAsync(recipeId);
            _mapper.Map(updateRecipeDTO, recipe);
            recipe.Image = await _imageRepository.Upload(updateRecipeDTO.Image, $"{recipeId}");
            _applicationRepository.UpdateRecipeAsync(recipe);
            await _applicationRepository.SaveChangesAsync();
            return NoContent();
        }

        [HttpPatch("{recipeId}")]
        public async Task<ActionResult<Recipe>> UpdateRecipe (int recipeId, JsonPatchDocument<UpdateRecipeDTO> patchDocument)
        {
            if(!await _applicationRepository.ExistsRecipeAsync(recipeId))
            {
                return NotFound();
            }
            var recipe = await _applicationRepository.GetRecipeAsync(recipeId);

            var recipePatch = _mapper.Map<UpdateRecipeDTO>(recipe);

            patchDocument.ApplyTo(recipePatch, ModelState);

            if (!TryValidateModel(recipePatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(recipePatch, recipe);
            _applicationRepository.UpdateRecipeAsync(recipe);
            await _applicationRepository.SaveChangesAsync();

            return NoContent();
        }
        [HttpDelete("{recipeId}")]
        public async Task<ActionResult<Recipe>> DeleteRecipe(int recipeId)
        {
            if (!await _applicationRepository.ExistsRecipeAsync(recipeId))
            {
                return NotFound();
            }
            var recipe = await _applicationRepository.GetRecipeAsync(recipeId);
            _applicationRepository.DeleteRecipeAsync(recipe);
            await _applicationRepository.SaveChangesAsync();
            return NoContent();
        }
       
    }
}
