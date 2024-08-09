using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
			List<Category> categories = new List<Category>();
			HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/categories").Result;
			if (response.IsSuccessStatusCode)
			{
				string data = response.Content.ReadAsStringAsync().Result;
				categories = JsonConvert.DeserializeObject<List<Category>>(data);
			}
			return View(categories);
		}
	}
}
