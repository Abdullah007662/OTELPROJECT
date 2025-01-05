using Microsoft.AspNetCore.Mvc;

namespace OteLProjectWebUI.Controllers
{
    public class MessageCategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
