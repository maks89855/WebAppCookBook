using Microsoft.Extensions.Options;
using System.Text.Json;

namespace WebAppCookBook.Frontend
{
    public class Client
    {
  //      private HttpClient client;
		//private readonly JsonSerializerOptions options = new JsonSerializerOptions()
		//{
		//	PropertyNameCaseInsensitive = true,
		//	PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
		//};
		//public Client(HttpClient httpClient)
  //      {
  //          client = httpClient;
  //      }
  //      public async Task<Category> GetCategoryAsync()
  //      {
  //          var responseMessage = await this.client.GetAsync("/category");
		//	if (responseMessage != null)
		//	{
		//		var stream = await responseMessage.Content.ReadAsStreamAsync();
		//		return await JsonSerializer.DeserializeAsync<Category>(stream, options);
		//	}
  //          return new Category();
		//}

    }

	/* 
	  private readonly JsonSerializerOptions options = new JsonSerializerOptions()
      {
         PropertyNameCaseInsensitive = true,
         PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
      };

      private readonly HttpClient client;
      private readonly ILogger<PizzaClient> _logger;

      public PizzaClient(HttpClient client, ILogger<PizzaClient> logger)
      {
         this.client = client;
         this._logger = logger;
      }

      public async Task<PizzaInfo[]> GetPizzasAsync()
      {
         try {
            var responseMessage = await this.client.GetAsync("/pizzainfo");
            
            if(responseMessage!=null)
            {
               var stream = await responseMessage.Content.ReadAsStreamAsync();
               return await JsonSerializer.DeserializeAsync<PizzaInfo[]>(stream, options);
            }
         }
         catch(HttpRequestException ex)
         {
            _logger.LogError(ex.Message);
            throw;
         }
         return new PizzaInfo[] {};
    */
}
