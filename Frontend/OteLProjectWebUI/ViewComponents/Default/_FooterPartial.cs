using Microsoft.AspNetCore.Mvc;

namespace OteLProjectWebUI.ViewComponents.Default
{
    public class _FooterPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
