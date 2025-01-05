using Microsoft.AspNetCore.Mvc;

namespace OteLProjectWebUI.ViewComponents.Default
{
    public class _ScriptPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
