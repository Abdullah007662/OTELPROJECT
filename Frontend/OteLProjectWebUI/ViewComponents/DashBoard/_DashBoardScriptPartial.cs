using Microsoft.AspNetCore.Mvc;

namespace OteLProjectWebUI.ViewComponents.DashBoard
{
    public class _DashBoardScriptPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
