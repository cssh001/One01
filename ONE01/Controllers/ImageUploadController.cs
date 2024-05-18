using Microsoft.AspNetCore.Mvc;
using ONE01.Services;

namespace ONE01.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImageUploadController : ControllerBase
    {
        private readonly IWebHostEnvironment _environment;

        public ImageUploadController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        [HttpPost("upload/{folder}")]
        public async Task<IActionResult> Upload(IFormFile file, string folder = "default")
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            // Generate a unique file name
            //var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var fileName = Path.GetFileNameWithoutExtension(file.FileName) // Get original filename without extension
                          + "_" + DateTime.UtcNow.ToString("yyyyMMdd_HHmmss") // Add current date/time in UTC format
                          + Path.GetExtension(file.FileName);

            // Combine the wwwroot/uploads folder path with the generated file name
            var uploadFolder = Path.Combine(_environment.WebRootPath, "images\\"+ folder);
            var filePath = Path.Combine(uploadFolder, fileName);

            // Save the uploaded file to the server
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return Ok( new { filePath, fileName});
        }
        [HttpGet("get/{folder}/{fileName}")]
        public Task<IActionResult> GetImage(string folder, string fileName)
        {
            string imagePath = Path.Combine(_environment.WebRootPath,  "images\\"+folder, fileName);

            // Check if the file exists
            if (!System.IO.File.Exists(imagePath))
            {
                return Task.FromResult<IActionResult>(NotFound("Image not found."));
            }

            // Read the image data into a byte array
            byte[] imageBytes = System.IO.File.ReadAllBytes(imagePath);

            // Return the image data with appropriate content type
            return Task.FromResult<IActionResult>(File(imageBytes, "image/jpeg")); // Adjust content type based on image format
        }
    }
}
