using Microsoft.AspNetCore.Mvc;

namespace OteLProjectWebUI.Controllers
{
    public class AdminPaneliController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
