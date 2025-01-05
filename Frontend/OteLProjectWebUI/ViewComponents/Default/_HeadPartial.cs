using Microsoft.AspNetCore.Mvc;

namespace OteLProjectWebUI.ViewComponents.Default
{
    //[ViewComponent(Name ="_HeadPartial")]
    ///İster bu Şekilde Kullan İster Class Adında bir klasör oluştur ve onunla birlikte çagır başka viewcomponent kullanım sekilleride vardir
    public class _HeadPartial:ViewComponent
    {
        //ViewComponent Sınıfından miras alan bu class IActionResult(Aksiyon Sonucu) degil Onun Yerine IViewComponentResult İnterfacesinden birmethod oluşturulur.
        // Invoke Methodu Default olarak cagırılır ve sytnaxda da ilk baştaki default ı alır .Eger bunu yapmazsan bu sınıfın ve aksiyon methodunu ViewComponent Attribute ile işaretlememiz gerekiyor olacaktır
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
