using Microsoft.AspNetCore.Mvc;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace WebAppCookBook.API.Service
{
    public class ImageRepository : IImageRepository
    {
        private readonly IWebHostEnvironment _environment;
        public ImageRepository(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

		public async Task<string> Upload(IFormFile file)
		{
			var idImage = new Guid();
            var path = _environment.WebRootPath + $"/images";
			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}
			using (var stream = new FileStream(path + $"/{idImage}.jpg", FileMode.Create))
			{
				await file.CopyToAsync(stream);
			}
			return idImage.ToString();
		}

		public async Task<string> Upload(IFormFile file, string subPath)
        {
			var idImage = Guid.NewGuid();
            var path = _environment.WebRootPath + $"/images/{subPath}";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            using (var stream = new FileStream(path + $"/{idImage}.jpg", FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return idImage.ToString()+".jpg";        
        }
		public async Task<string> Upload(IFormFile file, string subPath, string name)
		{			
			var path = _environment.WebRootPath + $"/images/{subPath}";
			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}
			using (var stream = new FileStream(path + $"/{name}.jpg", FileMode.Create))
			{
				await file.CopyToAsync(stream);
			}
			return name + ".jpg";
		}
	}
}
