using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OtelWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileImageController : ControllerBase
    {
        [DisableRequestSizeLimit]
        [HttpPost]
        public async Task<IActionResult> UploadImage([FromForm] IFormFile file)
        {
            // Benzersiz bir dosya adı oluştur
            var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);

            // "Images" klasörünün tam yolunu oluştur
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images");

            // Eğer "Images" klasörü yoksa oluştur
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            // Dosya için tam yolu oluştur
            var filePath = Path.Combine(folderPath, fileName);

            // Dosya akışını kullanarak dosyayı kaydet
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            //// Kaydedilen dosyanın URL'sini döndür (isteğe bağlı)
            //var fileUrl = $"/Images/{fileName}";

            return Created("",fileName);
        }

    }
}
