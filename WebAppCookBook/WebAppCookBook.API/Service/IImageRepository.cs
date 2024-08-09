namespace WebAppCookBook.API.Service
{
    public interface IImageRepository
    {
		public Task<string> Upload(IFormFile file, string path, string name);
		public Task<string> Upload(IFormFile file, string path);
		public Task<string> Upload(IFormFile file);
	}
}