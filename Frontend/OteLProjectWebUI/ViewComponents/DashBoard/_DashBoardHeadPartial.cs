using Microsoft.AspNetCore.Mvc;

namespace OteLProjectWebUI.ViewComponents.DashBoard
{
    public class _DashBoardHeadPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();  
        }
    }
}
