using Microsoft.AspNetCore.Mvc;

namespace OteLProjectWebUI.Controllers
{
    public class DashBoardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
