using Microsoft.AspNetCore.Mvc;

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
            var uploadFolder = Path.Combine(_environment.WebRootPath, "images\\" + folder);
            var filePath = Path.Combine(uploadFolder, fileName);

            // Save the uploaded file to the server
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return Ok(new { filePath, fileName });
        }

        [HttpPost("upload/multi/{folder}")]
        public async Task<IActionResult> UploadMulti(IFormFile[] files, string folder)
        {
            if (files == null || files.Length == 0)
            {
                return BadRequest("No files uploaded.");
            }

            var uploadedFiles = new List<Dictionary<string, string>>();

            foreach (var file in files)
            {
                if (file == null || file.Length == 0)
                {
                    continue; // Skip empty files
                }

                var fileName = Path.GetFileNameWithoutExtension(file.FileName) // Get original filename without extension
                          + "_" + DateTime.UtcNow.ToString("yyyyMMdd_HHmmss") // Add current date/time in UTC format
                          + Path.GetExtension(file.FileName);

                var uploadFolder = Path.Combine(_environment.WebRootPath, "images\\TourImages\\" + folder);
                if (!Directory.Exists(uploadFolder))
                {
                    Directory.CreateDirectory(uploadFolder);
                }
                var filePath = Path.Combine(uploadFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                uploadedFiles.Add(new Dictionary<string, string>()
                {
                  { "fileName", fileName },
                  { "filePath", filePath }
                });
            }

            return Ok(uploadedFiles);
        }

        [HttpDelete("delete/{filepath}")]
        public IActionResult DeleteImage(string filepath, string filename)
        {
            string filePath = Path.Combine(_environment.WebRootPath, "images\\" + filepath, filename);

            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
                return Ok(new { Message = "Image Deleted Success as:" + filename });
            }
            else
            {
                return NotFound(new { Message = "Has no existing image for deleting" });
            }
        }

        [HttpGet("get/{folder}/{fileName}")]
        public Task<IActionResult> GetImage(string folder, string fileName)
        {
            string imagePath = Path.Combine(_environment.WebRootPath, "images\\" + folder, fileName);

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
