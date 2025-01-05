using Microsoft.AspNetCore.Mvc;

namespace OteLProjectWebUI.ViewComponents.Default
{
    public class _TrailerPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
