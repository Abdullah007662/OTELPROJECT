using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace OteLProjectWebUI.Controllers
{
    public class AdminFileController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(IFormFile file)
        {
            var stream = new MemoryStream();//Bir Dosya Yükleme İşlemi Yapacağız.
            await file.CopyToAsync(stream);//Dosyayı ilgili akış üzerinden kopyalayacagım.
            var bytes = stream.ToArray();//Bytes dizi olarak tutuyoruz.


            ByteArrayContent byteArrayContent = new ByteArrayContent(bytes);
            byteArrayContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);
            MultipartFormDataContent multipartFormDataContent = new MultipartFormDataContent();
            multipartFormDataContent.Add(byteArrayContent, "file", file.FileName);
            var httpclient = new HttpClient();
            await httpclient.PostAsync("http://localhost:5132/api/FileProcess", multipartFormDataContent);


            return View();
        }
    }
}
