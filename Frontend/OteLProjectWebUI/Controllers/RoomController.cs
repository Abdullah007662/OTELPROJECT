using Microsoft.AspNetCore.Mvc;

namespace OteLProjectWebUI.Controllers
{
    public class RoomController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
