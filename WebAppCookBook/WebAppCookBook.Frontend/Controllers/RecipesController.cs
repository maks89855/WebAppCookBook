using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json;
using WebAppCookBook.Models;
using WebAppCookBook.API.DTOModels;
using WebAppCookBook.DTOModels;
using WebAppCookBook.Frontend.Models;
using WebAppCookBook.Models;

namespace WebAppCookBook.Frontend.Controllers
{
	public class RecipesController : Controller
	{
		Uri baseAddress = new Uri("https://localhost:7027/api");
		private readonly HttpClient _client;
		public RecipesController()
		{
			_client = new HttpClient();
			_client.BaseAddress = baseAddress;
		}
		[HttpGet]
		public IActionResult Index()
		{
			List<RecipeViewModel> recipes = new List<RecipeViewModel>();
			HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + $"/recipes").Result;
			if (response.IsSuccessStatusCode)
			{
				string data = response.Content.ReadAsStringAsync().Result;
				recipes = JsonConvert.DeserializeObject<List<RecipeViewModel>>(data);
			}
			return View(recipes);
		}
		[HttpGet]
		public IActionResult Details(int recipeId)
        {
			RecipeViewModel recipe = new RecipeViewModel();
			HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + $"/recipes/{recipeId}").Result;
			if (response.IsSuccessStatusCode)
			{
				string data = response.Content.ReadAsStringAsync().Result;
				recipe = JsonConvert.DeserializeObject<RecipeViewModel>(data);
            }
			return View(recipe);
		}
		[HttpGet]
		public IActionResult AddRecipe()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> AddRecipe(int categoryId, CreateRecipeModel model)
		{
			using var formData = new MultipartFormDataContent();
			formData.Add(new StringContent(model.Name), name: "Name");
			formData.Add(new StringContent(model.Description), name: "Description");

			await using var stream = model.Image.OpenReadStream();
			var content = new StreamContent(stream);
			content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(model.Image.ContentType);
            formData.Add(new StringContent(model.Description), name: "Description");
			formData.Add(content, name: "Image", model.Image.Name);
			if(model.Ingredients.Count != 0)
			{
                for (int i = 0; i < model.Ingredients.Count; i++)
                {
                    var json = JsonConvert.SerializeObject(model.Ingredients[i]);
                    formData.Add(new StringContent(json), "Ingredients");
                }
            }
			if(model.Ingredients.Count != 0)
			{
                for (int i = 0; i < model.StepsCooking.Count; i++)
                {
                    var json = JsonConvert.SerializeObject(model.StepsCooking[i]);
                    formData.Add(new StringContent(json), "StepsCooking");
                }
            }           
            HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + $"/recipes/{categoryId}", formData).Result;
			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("Details", new
				{
					recipeId = response.Headers.Location.Segments[3]
				});
			}
			return View();
        }
		[HttpGet]
		public IActionResult EditRecipe(int recipeId)
		{
            RecipeViewModel recipe = new RecipeViewModel();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + $"/recipes/{recipeId}").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                recipe = JsonConvert.DeserializeObject<RecipeViewModel>(data);
            }
            return View(recipe);
		}
		[HttpPost]
		public async Task<IActionResult> EditRecipe(int Id, UpdateRecipeViewModel updateModel)
		{
			var recipePatch = new JsonPatchDocument<UpdateRecipeViewModel>();
			recipePatch.Replace(r => r.Name, updateModel.Name);
			recipePatch.Replace(r => r.Description, updateModel.Description);
			HttpResponseMessage response = _client.PatchAsync(_client.BaseAddress + $"/recipes/{Id}",
				new StringContent(JsonConvert.SerializeObject(recipePatch), Encoding.UTF8, "application/json-patch+json")).Result;
			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("Details", new
				{
					recipeId = Id
                });
			}
			return View();
		}

        [HttpDelete] 
		public IActionResult DeleteRecipe(int recipeId)
		{
			return Ok(recipeId);
		}
	}
}
