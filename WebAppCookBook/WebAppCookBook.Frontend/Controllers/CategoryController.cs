using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebAppCookBook.Frontend.Models;

namespace WebAppCookBook.Frontend.Controllers
{
	public class CategoryController : Controller
	{
		Uri baseAddress = new Uri("https://localhost:7027/api");
		private readonly HttpClient _client;

        public CategoryController()
        {
            _client = new HttpClient();
			_client.BaseAddress = baseAddress;
        }

		[HttpGet]
        public IActionResult Index()
		{
			List<CategoryViewModel> categories = new List<CategoryViewModel>();
			HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/categories").Result;
			if (response.IsSuccessStatusCode)
			{
				string data = response.Content.ReadAsStringAsync().Result;
				categories = JsonConvert.DeserializeObject<List<CategoryViewModel>>(data);
			}
			return PartialView(categories);
		}
		[HttpGet]
		public IActionResult GetCategory(int categoryId)
		{
			List<CategoryViewModel> categories = new List<CategoryViewModel>();
			HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/categories/"+categoryId).Result;
			if (response.IsSuccessStatusCode)
			{
				string data = response.Content.ReadAsStringAsync().Result;
				categories = JsonConvert.DeserializeObject<List<CategoryViewModel>>(data);
			}
			return View(categories);
		}
	}
}
