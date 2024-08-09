using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using WebAppCookBook.API.DTOModels;
using WebAppCookBook.DTOModels;
using WebAppCookBook.Models;
using WebAppCookBook.Service;

namespace WebAppCookBook.Controllers
{
    [Route("api/recipes/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly IMapper _mapper;

        public CategoryController(IApplicationRepository applicationRepository, IMapper mapper)
        {
            this._applicationRepository = applicationRepository;
            this._mapper = mapper;
        }
        [HttpGet("{categoryId}", Name = "GetCategory")]
        public async Task<ActionResult<CategoryDTO>> GetCategoryAsync(
            int categoryId)
        {
            var category = await _applicationRepository.GetCategoryAsync(categoryId);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<CategoryDTO>(category));
        }
        [HttpHead]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategoriesAsync(
            string? searchCategory)
        {
            var categories = await _applicationRepository.GetCategoriesAsync(searchCategory);
            return Ok(_mapper.Map<IEnumerable<CategoryDTO>>(categories));
        }
        [HttpPost]
        public async Task<ActionResult<Category>> AddCategory(CreateCategoryDTO categoryDTO)
        {
            var category = _mapper.Map<Category>(categoryDTO);
            await _applicationRepository.AddCategoryAsync(category);
            await _applicationRepository.SaveChangesAsync();
            var returnCategory = _mapper.Map<CategoryDTO>(category);
            return CreatedAtRoute("GetCategory", new
            {
                categoryId = category.Id
            }, returnCategory);
        }
        [HttpOptions]
        public IActionResult GetCategoryOptions()
        {
            Response.Headers.Add("Allow", "GET, POST");
            return Ok();
        }

        [HttpPut("{categoryId}")]
        public async Task<ActionResult<Category>> UpdateCategory(int categoryId, UpdateCategoryDTO updateCategoryDTO)
        {
            if (!await _applicationRepository.ExistsCategoryAsync(categoryId))
            {
                var addCategory = _mapper.Map<Category>(updateCategoryDTO);
                addCategory.Id = categoryId;

                await _applicationRepository.AddCategoryAsync(addCategory);
                await _applicationRepository.SaveChangesAsync();

                var returnCategory = _mapper.Map<CategoryDTO>(addCategory);

                return CreatedAtRoute("GetCategory", new
                {
                    categoryId = returnCategory.Id
                }, returnCategory);
            }

            var category = await _applicationRepository.GetCategoryAsync(categoryId);

            _mapper.Map(updateCategoryDTO, category);
            _applicationRepository.UpdateCategoryAsync(category);
            await _applicationRepository.SaveChangesAsync();

            return NoContent();
        }
        [HttpPatch("{categoryId}")]
        public async Task<ActionResult<Category>> UpdateCategory(int categoryId, JsonPatchDocument<UpdateCategoryDTO> patchDocument)
        {
            if(!await _applicationRepository.ExistsCategoryAsync(categoryId))
            {
                return NotFound();
            }
            var category = await _applicationRepository.GetCategoryAsync(categoryId);

            var categoryPatch = _mapper.Map<UpdateCategoryDTO>(category);

            patchDocument.ApplyTo(categoryPatch, ModelState);

            if (!TryValidateModel(categoryPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(categoryPatch, category);

            _applicationRepository.UpdateCategoryAsync(category);
            await _applicationRepository.SaveChangesAsync();

            return NoContent();
        }
        [HttpDelete("{categoryId}")]
        public async Task<ActionResult<Category>> DeleteCategory(int categoryId)
        {
            if(!await _applicationRepository.ExistsCategoryAsync(categoryId))
            {
                return NotFound();
            }
            var category = await _applicationRepository.GetCategoryAsync(categoryId);
            _applicationRepository.DeleteCategoryAsync(category);
            await _applicationRepository.SaveChangesAsync();
            return NoContent();
        }
    }
}
